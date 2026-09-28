using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.ViewModel;
using HerkesYazarOlsun.Servis.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
namespace HerkesYazarOlsun.Servis.Controllers;

[ApiController, Route("api/makaleler")]
public class MakalelerController : ControllerBase
{
    private readonly IMakalelerService _makalelerService;

    public MakalelerController(IMakalelerService makalelerService)
    {
        _makalelerService = makalelerService ?? throw new ArgumentNullException(nameof(makalelerService));
    }

    private long AuthorId => User.Identity?.IsAuthenticated == true && long.TryParse(User.FindFirst("user_id")?.Value, out var id) ? id : 0;
    [HttpGet]
    public async Task<ActionResult<MakaleSayfa>> List(long? author = null, bool drafts = false, int page = 1, int pageSize = 12, CancellationToken ct = default)
    {
        if (page < 1 || page > 100000 || pageSize < 1 || pageSize > 50) return BadRequest();
        if (drafts && (AuthorId <= 0 || author != AuthorId)) return Forbid();
        return await _makalelerService.ListAsync(author, drafts, page, pageSize, ct);
    }
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Makale>> Read(Guid id, CancellationToken ct)
    {
        var article = await _makalelerService.GetVisibleAsync(id, AuthorId, ct);
        return article == null ? NotFound() : Ok(article);
    }
    [HttpGet("{id:guid}/belge")]
    public async Task<IActionResult> Document(Guid id, CancellationToken ct)
    {
        var article = await _makalelerService.GetVisibleAsync(id, AuthorId, ct);
        if (article == null) return NotFound();
        var bytes = await _makalelerService.GetDocumentAsync(id, ct);
        if (bytes == null) return NotFound();
        Response.Headers.CacheControl = "private, no-store";
        return File(bytes, article.Uzanti == ".pdf" ? "application/pdf" : "application/vnd.openxmlformats-officedocument.wordprocessingml.document", enableRangeProcessing: true);
    }
    [Authorize, HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        if (AuthorId <= 0) return Forbid();
        var article = await _makalelerService.GetByIdAsync(id, ct);
        if (article == null) return NotFound();
        if (article.YazarId != AuthorId) return Forbid();
        await _makalelerService.DeleteAsync(article, ct);
        return NoContent();
    }
    [Authorize, HttpPost, RequestSizeLimit(22 * 1024 * 1024), EnableRateLimiting("article-upload")]
    public async Task<IActionResult> Create([FromForm] string baslik, IFormFile dosya, CancellationToken ct)
    {
        var author = await _makalelerService.GetAuthorAsync(AuthorId, ct);
        if (author == null) return Forbid();
        var extension = Path.GetExtension(dosya?.FileName ?? "").ToLowerInvariant();
        if (string.IsNullOrWhiteSpace(baslik) || baslik.Length > 200 || dosya == null || dosya.Length == 0 || dosya.Length > 20 * 1024 * 1024 || (extension != ".docx" && extension != ".pdf"))
            return BadRequest(new { message = "Başlık ve en fazla 20 MB .docx veya PDF dosyası gerekir." });
        using var stream = new MemoryStream();
        await dosya.CopyToAsync(stream, ct);
        stream.Position = 0;
        string text;
        try { text = MakaleDocumentReader.Read(stream, extension); }
        catch (InvalidDataException ex) { return BadRequest(new { message = ex.Message }); }
        var article = new Makale { YazarId = author.ID, Yazar = author.USERNAME ?? "", Baslik = baslik.Trim(), Metin = text, Uzanti = extension };
        await _makalelerService.CreateAsync(article, stream.ToArray(), ct);
        return CreatedAtAction(nameof(Read), new { id = article.Id }, article.Id);
    }
    [Authorize, HttpPost("{id:guid}/yayinla")]
    public async Task<IActionResult> Publish(Guid id, CancellationToken ct)
    {
        if (AuthorId <= 0) return Forbid();
        var article = await _makalelerService.GetByIdAsync(id, ct);
        if (article == null) return NotFound();
        if (article.YazarId != AuthorId) return Forbid();
        await _makalelerService.PublishAsync(id, AuthorId, DateTimeOffset.UtcNow, ct);
        return NoContent();
    }
}

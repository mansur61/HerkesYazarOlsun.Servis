using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.ViewModel;
using HerkesYazarOlsun.Servis.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.RateLimiting;
namespace HerkesYazarOlsun.Servis.Controllers;

[ApiController, Route("api/makaleler")]
public class MakalelerController(DbContext db) : ControllerBase
{
    private long AuthorId => User.Identity?.IsAuthenticated == true && long.TryParse(User.FindFirst("user_id")?.Value, out var id) ? id : 0;
    [HttpGet]
    public async Task<ActionResult<MakaleSayfa>> List(long? author = null, bool drafts = false, int page = 1, int pageSize = 12, CancellationToken ct = default)
    {
        if (page < 1 || page > 100000 || pageSize < 1 || pageSize > 50) return BadRequest();
        if (drafts && (AuthorId <= 0 || author != AuthorId)) return Forbid();
        var query = db.Set<Makale>().AsNoTracking().Where(x => (author == null || x.YazarId == author) && (drafts || x.YayinTarihi != null));
        var items = await query.OrderByDescending(x => x.YayinTarihi).ThenByDescending(x => x.Id)
            .Skip((page - 1) * pageSize).Take(pageSize + 1)
            .Select(x => new MakaleOzet { Id = x.Id, YazarId = x.YazarId, Yazar = x.Yazar, Baslik = x.Baslik, YayinTarihi = x.YayinTarihi }).ToListAsync(ct);
        return new MakaleSayfa { Page = page, HasMore = items.Count > pageSize, Items = items.Take(pageSize).ToList() };
    }
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Makale>> Read(Guid id, CancellationToken ct)
    {
        var article = await db.Set<Makale>().AsNoTracking().SingleOrDefaultAsync(x => x.Id == id && (x.YayinTarihi != null || x.YazarId == AuthorId), ct);
        return article == null ? NotFound() : Ok(article);
    }
    [HttpGet("{id:guid}/belge")]
    public async Task<IActionResult> Document(Guid id, CancellationToken ct)
    {
        var article = await db.Set<Makale>().AsNoTracking().SingleOrDefaultAsync(x => x.Id == id && (x.YayinTarihi != null || x.YazarId == AuthorId), ct);
        if (article == null) return NotFound();
        var bytes = await db.Set<MakaleBelge>().AsNoTracking().Where(x => x.Id == id).Select(x => x.Icerik).SingleOrDefaultAsync(ct);
        if (bytes == null) return NotFound();
        Response.Headers.CacheControl = "private, no-store";
        return File(bytes, article.Uzanti == ".pdf" ? "application/pdf" : "application/vnd.openxmlformats-officedocument.wordprocessingml.document", enableRangeProcessing: true);
    }
    [Authorize, HttpDelete("{id:guid}"), HttpPost("{id:guid}/sil")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        if (AuthorId <= 0) return Forbid();
        var article = await db.Set<Makale>().SingleOrDefaultAsync(x => x.Id == id, ct);
        if (article == null) return NotFound();
        if (article.YazarId != AuthorId) return Forbid();
        db.Remove(article); // The original document is removed by the database cascade.
        await db.SaveChangesAsync(ct);
        return NoContent();
    }
    [Authorize, HttpPost, RequestSizeLimit(22 * 1024 * 1024), EnableRateLimiting("article-upload")]
    public async Task<IActionResult> Create([FromForm] string baslik, IFormFile dosya, CancellationToken ct)
    {
        var author = await db.Set<Users>().AsNoTracking().SingleOrDefaultAsync(x => x.ID == AuthorId && x.IS_DELETED == 0, ct);
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
        db.Add(article);
        db.Add(new MakaleBelge { Id = article.Id, Icerik = stream.ToArray() });
        await db.SaveChangesAsync(ct);
        return CreatedAtAction(nameof(Read), new { id = article.Id }, article.Id);
    }
    [Authorize, HttpPost("{id:guid}/yayinla")]
    public async Task<IActionResult> Publish(Guid id, CancellationToken ct)
    {
        if (AuthorId <= 0) return Forbid();
        var article = await db.Set<Makale>().AsNoTracking().SingleOrDefaultAsync(x => x.Id == id, ct);
        if (article == null) return NotFound();
        if (article.YazarId != AuthorId) return Forbid();
        await db.Set<Makale>().Where(x => x.Id == id && x.YazarId == AuthorId && x.YayinTarihi == null)
            .ExecuteUpdateAsync(update => update.SetProperty(x => x.YayinTarihi, DateTimeOffset.UtcNow), ct);
        return NoContent();
    }
}

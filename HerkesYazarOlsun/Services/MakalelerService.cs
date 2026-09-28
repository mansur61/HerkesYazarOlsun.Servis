using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace HerkesYazarOlsun.Servis.Services;

public sealed class MakalelerService : IMakalelerService
{
    private readonly DbContext _db;

    public MakalelerService(DbContext db)
    {
        _db = db ?? throw new ArgumentNullException(nameof(db));
    }

    public async Task<MakaleSayfa> ListAsync(long? author, bool drafts, int page, int pageSize, CancellationToken cancellationToken)
    {
        var query = _db.Set<Makale>().AsNoTracking()
            .Where(x => (author == null || x.YazarId == author) && (drafts || x.YayinTarihi != null));
        var items = await query.OrderByDescending(x => x.YayinTarihi).ThenByDescending(x => x.Id)
            .Skip((page - 1) * pageSize).Take(pageSize + 1)
            .Select(x => new MakaleOzet { Id = x.Id, YazarId = x.YazarId, Yazar = x.Yazar, Baslik = x.Baslik, YayinTarihi = x.YayinTarihi })
            .ToListAsync(cancellationToken);

        return new MakaleSayfa { Page = page, HasMore = items.Count > pageSize, Items = items.Take(pageSize).ToList() };
    }

    public Task<Makale?> GetVisibleAsync(Guid id, long authorId, CancellationToken cancellationToken) =>
        _db.Set<Makale>().AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == id && (x.YayinTarihi != null || x.YazarId == authorId), cancellationToken);

    public Task<byte[]?> GetDocumentAsync(Guid id, CancellationToken cancellationToken) =>
        _db.Set<MakaleBelge>().AsNoTracking().Where(x => x.Id == id).Select(x => x.Icerik).SingleOrDefaultAsync(cancellationToken);

    public Task<Users?> GetAuthorAsync(long authorId, CancellationToken cancellationToken) =>
        _db.Set<Users>().AsNoTracking().SingleOrDefaultAsync(x => x.ID == authorId && x.IS_DELETED == 0, cancellationToken);

    public Task<Makale?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
        _db.Set<Makale>().SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task CreateAsync(Makale article, byte[] document, CancellationToken cancellationToken)
    {
        _db.Add(article);
        _db.Add(new MakaleBelge { Id = article.Id, Icerik = document });
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Makale article, CancellationToken cancellationToken)
    {
        var document = await _db.Set<MakaleBelge>().SingleOrDefaultAsync(x => x.Id == article.Id, cancellationToken);
        if (document != null) _db.Remove(document);
        _db.Remove(article);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public Task<int> PublishAsync(Guid id, long authorId, DateTimeOffset publishedAt, CancellationToken cancellationToken) =>
        _db.Set<Makale>().Where(x => x.Id == id && x.YazarId == authorId && x.YayinTarihi == null)
            .ExecuteUpdateAsync(update => update.SetProperty(x => x.YayinTarihi, publishedAt), cancellationToken);
}
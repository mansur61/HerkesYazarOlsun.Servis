using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.ViewModel;

namespace HerkesYazarOlsun.Servis.Services;

public interface IMakalelerService
{
    Task<MakaleSayfa> ListAsync(long? author, bool drafts, int page, int pageSize, CancellationToken cancellationToken);
    Task<Makale?> GetVisibleAsync(Guid id, long authorId, CancellationToken cancellationToken);
    Task<byte[]?> GetDocumentAsync(Guid id, CancellationToken cancellationToken);
    Task<Users?> GetAuthorAsync(long authorId, CancellationToken cancellationToken);
    Task<Makale?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task CreateAsync(Makale article, byte[] document, CancellationToken cancellationToken);
    Task DeleteAsync(Makale article, CancellationToken cancellationToken);
    Task<int> PublishAsync(Guid id, long authorId, DateTimeOffset publishedAt, CancellationToken cancellationToken);
}
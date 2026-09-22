using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface IRefreshTokenService
    {
        RefreshToken? Ekle(RefreshToken entity, string? mail);
        RefreshToken? Guncelle(RefreshToken entity, long tcNo);
        RefreshToken? Get(long id);
        RefreshToken? GetByToken(string token);
        List<RefreshToken> GetActiveByUserId(long userId);
    }
}

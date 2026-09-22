using HerkesYazarOlsun.DataLayer.Repo;
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.DataLayer.Abstract
{
    public interface IRefreshTokenDal : IRepo<RefreshToken>
    {
        RefreshToken? GetByToken(string token);
        List<RefreshToken> GetActiveByUserId(long userId);
    }
}

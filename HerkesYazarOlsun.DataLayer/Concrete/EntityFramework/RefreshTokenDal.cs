using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Repo;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;

namespace HerkesYazarOlsun.DataLayer.Concrete.EntityFramework
{
    public class RefreshTokenDal : HybridRepo<RefreshToken>, IRefreshTokenDal
    {
        public RefreshTokenDal(SqlRepo<RefreshToken> sqlRepo, NpgsqlRepo<RefreshToken> npgsqlRepo, IConfiguration config)
            : base(sqlRepo, npgsqlRepo, config)
        {
        }

        public RefreshToken? GetByToken(string token)
        {
            return GetAllQueryableNoTracking(x => x.Token == token && (x.IS_DELETED == null || x.IS_DELETED == 0))
                .OrderByDescending(x => x.CreatedAt)
                .FirstOrDefault();
        }

        public List<RefreshToken> GetActiveByUserId(long userId)
        {
            var now = DateTime.UtcNow;

            return GetAllQueryableNoTracking(x =>
                    x.UserId == userId &&
                    (x.IS_DELETED == null || x.IS_DELETED == 0) &&
                    x.RevokedAt == null &&
                    x.ExpiresAt > now)
                .OrderByDescending(x => x.CreatedAt)
                .ToList();
        }
    }
}

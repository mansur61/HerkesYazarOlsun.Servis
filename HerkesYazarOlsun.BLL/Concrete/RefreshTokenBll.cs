using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Concrete
{
    public class RefreshTokenBll : IRefreshTokenService
    {
        private readonly IRefreshTokenDal _refreshTokenDal;

        public RefreshTokenBll(IRefreshTokenDal refreshTokenDal)
        {
            _refreshTokenDal = refreshTokenDal;
        }

        public RefreshToken? Ekle(RefreshToken entity, string? mail)
        {
            return _refreshTokenDal.Ekle(entity, mail ?? string.Empty);
        }

        public RefreshToken? Guncelle(RefreshToken entity, long tcNo)
        {
            return _refreshTokenDal.Update(entity, tcNo);
        }

        public RefreshToken? Get(long id)
        {
            return _refreshTokenDal.Get(id);
        }

        public RefreshToken? GetByToken(string token)
        {
            return _refreshTokenDal.GetByToken(token);
        }

        public List<RefreshToken> GetActiveByUserId(long userId)
        {
            return _refreshTokenDal.GetActiveByUserId(userId);
        }
    }
}

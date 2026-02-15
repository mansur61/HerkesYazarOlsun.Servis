using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;

namespace HerkesYazarOlsun.DataLayer.Concrete.EntityFramework
{
    public class CarouselDuyuruDal : HybridEntityRepositoryBase<CarouselDuyuru>, ICarouselDuyuruDal
    {
        public CarouselDuyuruDal(
         EfSqlEntityRepositoryBase<CarouselDuyuru> sqlRepo,
         EfNpSqlEntityRepositoryBase<CarouselDuyuru> npgsqlRepo,
         IConfiguration config)
         : base(sqlRepo, npgsqlRepo, config)
        {
        }
    }
}

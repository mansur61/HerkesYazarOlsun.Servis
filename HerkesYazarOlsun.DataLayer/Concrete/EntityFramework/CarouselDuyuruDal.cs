using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

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

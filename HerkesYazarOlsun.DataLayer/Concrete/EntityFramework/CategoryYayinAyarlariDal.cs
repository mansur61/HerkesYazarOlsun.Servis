using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;

namespace HerkesYazarOlsun.DataLayer.Concrete.EntityFramework
{ 
    public class CategoryYayinAyarlariDal : HybridEntityRepositoryBase<CategoryYayinAyarlari>, ICategoryYayinAyarlariDal
    {
        public CategoryYayinAyarlariDal(
         EfSqlEntityRepositoryBase<CategoryYayinAyarlari> sqlRepo,
         EfNpSqlEntityRepositoryBase<CategoryYayinAyarlari> npgsqlRepo,
         IConfiguration config)
         : base(sqlRepo, npgsqlRepo, config)
        {
        }
    }
}

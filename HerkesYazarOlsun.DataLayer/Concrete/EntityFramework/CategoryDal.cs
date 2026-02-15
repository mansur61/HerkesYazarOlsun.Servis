using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;

namespace HerkesYazarOlsun.DataLayer.Concrete.EntityFramework
{
    public class CategoryDal : HybridEntityRepositoryBase<Category>, ICategoryDal
    {
        public CategoryDal(
         EfSqlEntityRepositoryBase<Category> sqlRepo,
         EfNpSqlEntityRepositoryBase<Category> npgsqlRepo,
         IConfiguration config)
         : base(sqlRepo, npgsqlRepo, config)
        {
        }
    }
}

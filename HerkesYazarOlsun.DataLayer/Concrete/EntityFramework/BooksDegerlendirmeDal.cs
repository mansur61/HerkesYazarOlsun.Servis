using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace HerkesYazarOlsun.DataLayer.Concrete
{
    public class BooksDegerlendirmeDal : HybridEntityRepositoryBase<BooksDegerlendirme>, IBooksDegerlendirmeDal
    {
        public BooksDegerlendirmeDal(
         EfSqlEntityRepositoryBase<BooksDegerlendirme> sqlRepo,
         EfNpSqlEntityRepositoryBase<BooksDegerlendirme> npgsqlRepo,
         IConfiguration config)
         : base(sqlRepo, npgsqlRepo, config)
        {
        }
    }
}

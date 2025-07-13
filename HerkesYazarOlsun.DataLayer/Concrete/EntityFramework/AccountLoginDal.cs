using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Repo;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace HerkesYazarOlsun.DataLayer.Concrete.EntityFramework
{
    public class AccountLoginDal : HybridRepo<AccountLogin>, IAccountLoginDal
    {
        public AccountLoginDal(SqlRepo<AccountLogin> sqlRepo, NpgsqlRepo<AccountLogin> npgsqlRepo, IConfiguration config)
       : base(sqlRepo, npgsqlRepo, config)
        {
        }
    }
}

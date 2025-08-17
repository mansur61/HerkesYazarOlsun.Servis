using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Repo;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;

namespace HerkesYazarOlsun.DataLayer.Concrete.EntityFramework
{
    public class UsersDetailsDal : HybridRepo<UsersDetails>, IUsersDetailsDal
    {
        public UsersDetailsDal(SqlRepo<UsersDetails> sqlRepo, NpgsqlRepo<UsersDetails> npgsqlRepo, IConfiguration config)
       : base(sqlRepo, npgsqlRepo, config)
        {
        }
    }
}

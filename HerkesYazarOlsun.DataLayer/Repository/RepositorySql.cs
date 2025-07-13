using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.DataLayer.Repository
{
    public class RepositorySql<T> : RepositoryBase<T> where T : BaseEntity
    {
        public RepositorySql(SqlServerContext context) : base(context) { }

        public override long GetSequneceNextVal(string sequneceName)
        {
            // SQL Server'da sequence kullanıyorsan buraya yaz.
            throw new NotSupportedException("SQL Server için Sequence desteklenmiyor veya implemente edilmedi.");
        }
    }


}

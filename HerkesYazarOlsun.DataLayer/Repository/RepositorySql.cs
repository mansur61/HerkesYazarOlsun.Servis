using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace HerkesYazarOlsun.DataLayer.Repository
{
    public class RepositorySql<T> : RepositoryBase<T> where T : BaseEntity
    {
        private readonly SqlServerContext _context;

        public RepositorySql(SqlServerContext context) : base(context)
        {
            _context = context;
        }

        public override long GetSequneceNextVal(string sequenceName)
        {
            if (string.IsNullOrWhiteSpace(sequenceName))
                throw new ArgumentException("Sequence adı boş olamaz.", nameof(sequenceName));

            var connection = _context.Database.GetDbConnection();

            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                using var command = connection.CreateCommand();
                command.CommandText = $"SELECT NEXT VALUE FOR [{sequenceName}]"; // Güvenlik için köşeli parantez
                var result = command.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                    throw new InvalidOperationException($"Sequence '{sequenceName}' değeri alınamadı.");

                return Convert.ToInt64(result);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}

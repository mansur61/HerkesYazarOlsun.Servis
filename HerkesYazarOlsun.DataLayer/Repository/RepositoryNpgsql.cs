using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;
using System.Data;

namespace HerkesYazarOlsun.DataLayer.Repository
{
    public class RepositoryNpgsql<T> : RepositoryBase<T> where T : BaseEntity
    {
        public RepositoryNpgsql(HerkesYazaOlsunContext context) : base(context) { }

        public override long GetSequneceNextVal(string sequneceName)
        {
            using var connection = (NpgsqlConnection)_dbContext.Database.GetDbConnection();
            connection.Open();

            var cmd = new NpgsqlCommand("GetSequenceNextVal", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("nameSeq", NpgsqlDbType.Varchar, sequneceName);
            var output = new NpgsqlParameter("nextValue", NpgsqlDbType.Bigint)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(output);

            cmd.ExecuteNonQuery();

            return Convert.ToInt64(output.Value);
        }
    }

}

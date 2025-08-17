using Dapper;
using HerkesYazarOlsun.Model.Entity; 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design; 
using System.Dynamic;

namespace HerkesYazarOlsun.DataLayer.Context
{
    public class SqlServerContextFactory : IDesignTimeDbContextFactory<SqlServerContext>
    {
        public SqlServerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SqlServerContext>();             
            string baglanti = ConnectionConncet.GetSqlConnect();
            optionsBuilder.UseSqlServer(baglanti);

            //return new SqlServerContext();
            return new SqlServerContext(optionsBuilder.Options);
        }
    }
  
    public class SqlServerContext : BaseSqlDbContext
    {
        public SqlServerContext(DbContextOptions options) : base(options)
        {
        }
         

        public virtual DbSet<FAVORILER> FAVORILER { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<CarouselDuyuru> CarouselDuyuru { get; set; }

        public virtual DbSet<BooksDegerlendirme> BooksDegerlendirme { get; set; }
        public virtual DbSet<Odeme> Odeme { get; set; }
        public virtual DbSet<TALEPLER> TALEPLER { get; set; }
        public virtual DbSet<AccountLogin> AccountLogin { get; set; }
        public virtual DbSet<YayinAyarlari> YayinAyarlari { get; set; }

        public virtual DbSet<Bildirimler> Bildirimler { get; set; }
        public virtual DbSet<UsersDetails> UsersDetails { get; set; }
        public virtual DbSet<Profil> Profil { get; set; }
        public virtual DbSet<Ayarlar> Ayarlar { get; set; }

        public virtual DbSet<OdemeSponsorlari> OdemeSponsorlari { get; set; }
        public virtual DbSet<Sponsorlar> Sponsorlar { get; set; }
        public virtual DbSet<Kartlar> Kartlar { get; set; }
        public virtual DbSet<BooksComment> BooksComment { get; set; }
        public virtual DbSet<FavoriBooks> FavoriBooks { get; set; }
        public virtual DbSet<BooksStars> BooksStars { get; set; }
        public virtual DbSet<WriterStars> WriterStars { get; set; }
        public virtual DbSet<WriterFollow> WriterFollow { get; set; }
        public virtual DbSet<FAVORI_YAZARLAR> FAVORI_YAZARLAR { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<BooksPages> BooksPages { get; set; }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        /// <summary>
        /// ilgili db'ye bağlanma araçlarını sunar
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string baglanti = ConnectionConncet.GetSqlConnect();
                optionsBuilder.UseSqlServer(baglanti);
            }
        }

        /// <summary>
        /// İlgili bağlanan db'ye ait primary key foreign key vs gibi eklemeleri DbSet<T> yapısı eklemeden gerçekleştirilen yer.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override IList<T> SqlQueryDapper<T>(string sql, object[] parameters = null)
        {
            try
            {
                var connection = Database.GetDbConnection();
                dynamic temp = new ExpandoObject();
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        var _parameter = (Npgsql.NpgsqlParameter)parameter;
                        ((IDictionary<string, object>)temp)[_parameter.ParameterName] = _parameter.Value;
                    }
                }
                return connection.Query<T>(sql, (object)temp).ToList();
            }
            catch (Exception ex)
            {
                return new List<T>();
            }
        }


    }
}

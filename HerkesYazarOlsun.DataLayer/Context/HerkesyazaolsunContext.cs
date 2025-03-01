
using Dapper;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Dynamic;

namespace HerkesYazarOlsun.DataLayer.Context
{
    public class HerkesYazaOlsunContextFactory : IDesignTimeDbContextFactory<HerkesYazaOlsunContext>
    {
        public HerkesYazaOlsunContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HerkesYazaOlsunContext>();
            string baglanti = DbSettings.HerkesYazarOlsunDbContext;
            optionsBuilder.UseNpgsql(baglanti);

           //return new HerkesYazaOlsunContext(optionsBuilder.Options);
            return new HerkesYazaOlsunContext();
        }
    }

    public class HerkesYazaOlsunContext : BaseNpSqlDbContext // DbContext
    {

        public virtual DbSet<FAVORILER> FAVORILER { get; set; }
        public virtual DbSet<CarouselDuyuru> CarouselDuyuru { get; set; }
        
        public virtual DbSet<BooksDegerlendirme> BooksDegerlendirme { get; set; }
        public virtual DbSet<Odeme> Odeme { get; set; }
        public virtual DbSet<TALEPLER> TALEPLER { get; set; }        
        public virtual DbSet<AccountLogin> AccountLogin { get; set; }
        
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



        //public HerkesYazaOlsunContext(DbContextOptions<HerkesYazaOlsunContext> options) : base(options)
        //{

        //}

        //public HerkesYazaOlsunContext()
        //{
        //}


        /// <summary>
        /// ilgili db'ye bağlanma araçlarını sunar
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string baglanti = "Host=localhost;Port=5432;Database=HERKESYAZAROLSUN;User Id=postgres;Password=12345;Integrated Security=true;Pooling=true;";
            // var con = DbSettings.HerkesYazarOlsunDbContext;
            optionsBuilder.UseNpgsql(baglanti);

        }

        /// <summary>
        /// İlgili bağlanan db'ye ait primary key foreign key vs gibi eklemeleri DbSet<T> yapısı eklemeden gerçekleştirilen yer.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override IList<T> NpSqlQueryDapper<T>(string sql, object[] parameters = null)
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

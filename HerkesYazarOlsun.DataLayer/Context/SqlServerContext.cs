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


        public virtual DbSet<Favoriler> Favoriler { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<CarouselDuyuru> CarouselDuyuru { get; set; }

        public virtual DbSet<BooksDegerlendirme> BooksDegerlendirme { get; set; }
        public virtual DbSet<Odeme> Odeme { get; set; }
        public virtual DbSet<Talepler> Talepler { get; set; }
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
        public virtual DbSet<FavoriYazarlar> FavoriYazarlar { get; set; }
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

            modelBuilder.Entity<Users>()
                .HasOne(u => u.Profil)
                .WithOne(p => p.User)
                .HasForeignKey<Profil>(p => p.LoginUserId);

            // Users -> WriterFollowList (1 user, birden fazla follow)
            modelBuilder.Entity<WriterFollow>()
                .HasOne(wf => wf.YazarUsers)   // WriterFollow içindeki referans User
                .WithMany(u => u.WriterFollowList)  // User içindeki ICollection
                .HasForeignKey(wf => wf.YazarId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WriterFollow>()
                .HasOne(wf => wf.LoginUsers)   // WriterFollow içindeki referans LoginUser
                .WithMany(u => u.WriterFollowList) // User içindeki ICollection
                .HasForeignKey(wf => wf.LoginUserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Users -> WriterStarsList (1 user, birden fazla star)
            modelBuilder.Entity<WriterStars>()
                .HasOne(ws => ws.YazarUsers)
                .WithMany(u => u.WriterStarsList)
                .HasForeignKey(ws => ws.YazarId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WriterStars>()
                .HasOne(ws => ws.LoginUsers)
                .WithMany(u => u.WriterStarsList)
                .HasForeignKey(ws => ws.LoginUserId)
                .OnDelete(DeleteBehavior.Cascade);

             
            modelBuilder.Entity<Books>()
                .HasOne(b => b.Categories)              // her kitap bir kategoriye bağlı
                .WithMany()                           // kategori tarafında navigation yok
                .HasForeignKey(b => b.CategoriId)
                .OnDelete(DeleteBehavior.Restrict);   // kategoriyi silerken kitapları silmesin


            modelBuilder.Entity<Books>()
               .HasOne(b => b.BookYayinAyari)              // her kitap bir kategoriye bağlı
               .WithMany()                           // kategori tarafında navigation yok
               .HasForeignKey(b => b.YayinAyarId)
               .OnDelete(DeleteBehavior.Restrict);   // kategoriyi silerken kitapları silmesin

            modelBuilder.Entity<Books>()
                .HasMany(b => b.BooksPageList)      // kitap → birden çok sayfa
                .WithOne(p => p.Book)            // her sayfa → bir kitap
                .HasForeignKey(p => p.BooksId)    // FK BookId
                .OnDelete(DeleteBehavior.Cascade); // Book silinirse, ona bağlı olan BooksPages


            modelBuilder.Entity<BooksPages>()
                .HasOne(b => b.Book)
                .WithMany()
                .HasForeignKey(b => b.BooksId)
                .OnDelete(DeleteBehavior.Restrict); //BooksPages silmede Book silme

            modelBuilder.Entity<Books>()
                .HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.YazarId)
                .OnDelete(DeleteBehavior.Restrict); //Books silmede User/Yazarını silme

            modelBuilder.Entity<Books>()
               .HasMany(b => b.BooksComments)
               .WithOne(p => p.Books)
               .HasForeignKey(p => p.BookId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Books>()
               .HasMany(b => b.BooksDegerlendirme)
               .WithOne(p => p.Books)
               .HasForeignKey(p => p.BookId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Books>()
               .HasMany(b => b.BooksStars)
               .WithOne(p => p.Books)
               .HasForeignKey(p => p.BookId)
               .OnDelete(DeleteBehavior.Cascade);

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

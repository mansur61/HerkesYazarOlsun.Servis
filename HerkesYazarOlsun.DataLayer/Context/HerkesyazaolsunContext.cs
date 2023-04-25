
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HerkesYazarOlsun.DataLayer.Context
{
    public class HerkesyazarolsunContextFactory : IDesignTimeDbContextFactory<HerkesyazarolsunContext>
    {
        public HerkesyazarolsunContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HerkesyazarolsunContext>();
            string baglanti = DbSettings.HerkesYazarOlsunDbContext;
            optionsBuilder.UseNpgsql(baglanti);

            return new HerkesyazarolsunContext(optionsBuilder.Options);
        }
    }
    public class HerkesyazarolsunContext : DbContext //Base2DbContext 
    {

        public virtual DbSet<KISILER> KISILER { get; set; }

        public HerkesyazarolsunContext(DbContextOptions<HerkesyazarolsunContext> options): base(options)
        {
            
        }
       

        /// <summary>
        /// ilgili db'ye bağlanma araçlarını sunar
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string baglanti = 
            //"Host=localhost;Port=5432;Database=HERKESYAZAROLSUN;User Id=postgres;Password=12345;Integrated Security=true;Pooling=true;";
            //optionsBuilder.UseNpgsql(baglanti);
            DbSettings.HerkesYazarOlsunDbContext;
            optionsBuilder.UseNpgsql(baglanti);

        }

        /// <summary>
        /// İlgili bağlanan db'ye ait primary key foreign key vs gibi eklemeleri DbSet<T> yapısı eklemeden gerçekleştirilen yer
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


      
    }
}

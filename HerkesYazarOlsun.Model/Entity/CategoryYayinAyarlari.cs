 
using System.ComponentModel.DataAnnotations.Schema; 

namespace HerkesYazarOlsun.Model.Entity
{
    
    [Table(name: "CategoryYayinAyarlari")]
    public class CategoryYayinAyarlari : IEntity
    {
        public int? ID { get; set; }
        public int? ToplamYildiz { get; set; }
        public int? ToplamBegeni { get; set; }
        public int? ToplamYorum { get; set; }
        public int? ToplamDegerlendirme { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}

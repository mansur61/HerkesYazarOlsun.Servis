 
using System.ComponentModel.DataAnnotations.Schema; 

namespace HerkesYazarOlsun.Model.Entity
{
    
    [Table(name: "YayinAyarlari")]
    public class YayinAyarlari : IEntity
    {
        public int? ID { get; set; }
        public int? ToplamYildiz { get; set; }
        public int? ToplamBegeni { get; set; }
        public int? ToplamYorum { get; set; }
        public int? ToplamDegerlendirme { get; set; }
        public long? BookId { get; set; }
        public Books? Book  { get; set; }
    }
}

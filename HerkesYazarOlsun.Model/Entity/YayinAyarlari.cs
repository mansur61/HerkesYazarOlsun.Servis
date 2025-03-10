 
using System.ComponentModel.DataAnnotations.Schema; 

namespace HerkesYazarOlsun.Model.Entity
{
    
    [Table(name: "YayinAyarlari")]
    public class YayinAyarlari : BaseEntity
    {
        public int ToplamYildiz { get; set; }
        public int ToplamBegeni { get; set; }
        public int ToplamYorum { get; set; }
        public int ToplamDegerlendirme { get; set; }
    }
}

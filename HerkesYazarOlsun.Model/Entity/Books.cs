using System.ComponentModel.DataAnnotations.Schema;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "Books")]
    public class Books : NewBaseEntity
    {
        public string Name { get; set; }
        public string ONSOZ { get; set; }
        public string ONKAPAKFOTO { get; set; }
        public string ARKAKAPAKFOTO { get; set; }
        public string ONKAPAKFOTOPATH { get; set; }
        public string ARKAKAPAKFOTOPATH { get; set; }
        public string ARKAKAPAKYAZISI { get; set; }
        public bool TAMAMLANDIMI { get; set; }
        public long YazarId { get; set; }
        public bool YAYINDAMI { get; set; }
        public long CategoriId { get; set; }
    }
   
}

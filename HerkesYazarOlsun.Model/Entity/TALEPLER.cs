 
using System.ComponentModel.DataAnnotations.Schema; 

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "TALEPLER")]
    public class TALEPLER : NewBaseEntity
    {
        public string EMAIL { get; set; }
        public string? ADISOYADI { get; set; }
        public int? KONU_ID { get; set; }
        public string? KONU { get; set; }
        public DateTime? TARIHI { get; set; }
        public string? MESAJ { get; set; }
    }
}

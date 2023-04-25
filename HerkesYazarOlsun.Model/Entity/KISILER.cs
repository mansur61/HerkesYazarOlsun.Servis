
using System.ComponentModel.DataAnnotations.Schema;


namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "KISILER")]
    public class KISILER : NewBaseEntity
    {
        public string AD { get; set; }
        public string SOYAD { get; set; }
    }
}

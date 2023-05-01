
using System.ComponentModel.DataAnnotations.Schema;


namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "KISILER")]
    public class KISILER : NewBaseEntity
    {
        public string AD { get; set; }
        public string SOYAD { get; set; }
    }

    [Table(name: "TEST")]
    public class TEST : NewBaseEntity
    {
        public string AD { get; set; }
       
    }

    
}

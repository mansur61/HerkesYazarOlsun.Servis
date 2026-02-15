using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "Odeme")]
    public class Odeme : NewBaseEntity
    {        
        public long KitapId { get; set; }

        [DefaultValue(false)]
        public bool isOdeme { get; set; }
        public long LoginUserId { get; set; }
    }
   
}

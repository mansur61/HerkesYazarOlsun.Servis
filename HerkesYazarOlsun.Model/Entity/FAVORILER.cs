
using System.ComponentModel.DataAnnotations.Schema;


namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "FAVORILER")]
    public class FAVORILER : NewBaseEntity
    {
        public long BOOKS_ID { get; set; }
        public long USER_ID { get; set; }
    }

   

    
}

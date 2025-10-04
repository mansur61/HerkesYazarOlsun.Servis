
using System.ComponentModel.DataAnnotations.Schema;


namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "FavoriBooks")]
    public class FavoriBooks : NewBaseEntity
    {
        public long? BOOKS_ID { get; set; }
        public Books? Books { get; set; }
        public long? USER_ID { get; set; }
        public Users? Users { get; set; }
    }

   

    
}


using System.ComponentModel.DataAnnotations.Schema;


namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "FAVORILER")]
    public class FAVORILER : NewBaseEntity
    {
        public string BOOKS_ID { get; set; }
        public string USER_ID { get; set; }
    }

   

    
}

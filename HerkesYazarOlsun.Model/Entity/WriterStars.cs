using System.ComponentModel.DataAnnotations.Schema;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "WriterStars")]
    public class WriterStars : BaseEntity
    {
        public int StarPuani { get; set; }
        
        public long? LoginUserId { get; set; }
        public Users? LoginUser { get; set; }
        
        public long? YazarId { get; set; }
        public Users? Yazar { get; set; }
    }
}

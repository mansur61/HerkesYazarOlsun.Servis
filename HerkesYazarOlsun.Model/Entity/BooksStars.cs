using System.ComponentModel.DataAnnotations.Schema;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "BooksStars")]
    public class BooksStars : BaseEntity
    {
        public int StarPuani { get; set; }
        public long LoginUserId { get; set; }
        public Users? LoginUser { get; set; }
        public long? BookId { get; set; }
        public Books? Book { get; set; }
    }
}

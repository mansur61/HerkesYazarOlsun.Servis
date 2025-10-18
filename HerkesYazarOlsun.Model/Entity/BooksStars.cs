using System.ComponentModel.DataAnnotations.Schema;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "BooksStars")]
    public class BooksStars : BaseEntity
    {
        public int StarPuani { get; set; }
        public int LoginUserId { get; set; }
        public long? BookId { get; set; }
        public Books? Book { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "BooksStars")]
    public class BooksStars : BaseEntity
    {
        public int StarPuani { get; set; }
        public int LoginUserId { get; set; }
        public int BookaId { get; set; }
    }
}

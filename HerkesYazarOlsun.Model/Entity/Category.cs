using System.ComponentModel.DataAnnotations.Schema;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "Category")]
    public class Category : BaseEntity
    {
        public int BooksId { get; set; }
        public string Name { get; set; }
    }
}

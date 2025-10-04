using System.ComponentModel.DataAnnotations.Schema;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "Category")]
    public class Category : IEntity
    {
        public long? ID { get; set; }
        public string Name { get; set; } 
    }
}

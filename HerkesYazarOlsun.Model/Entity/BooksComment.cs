using System.ComponentModel.DataAnnotations.Schema;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "BooksComment")]
    public class BooksComment : NewBaseEntity
    {
        public string NAME { get; set; }
        public string EMAIL { get; set; }
        public string ACIKLAMA { get; set; }
        public int? BookId { get; set; }
        public Books? Books { get; set; }
        public long LoginUserId { get; set; }
        public int? StarPuani { get; set; }

    }
}

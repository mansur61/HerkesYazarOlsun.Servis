using System.ComponentModel.DataAnnotations.Schema;

namespace HerkesYazarOlsun.Model.Entity
{
   
    [Table(name: "BooksPages")]
    public class BooksPages : NewBaseEntity
    {
        public string PageWrite { get; set; }
        public string PageWriteBase64 { get; set; }
        public string PageFoto { get; set; }

        // Kitap veritabanı id bilgisi 
        public long BookId { get; set; }
        public Books Book { get; set; }

    }
}

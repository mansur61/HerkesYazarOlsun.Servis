using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.Model.Entity
{
   
    [Table(name: "BooksPages")]
    public class BooksPages : NewBaseEntity
    {
        public string PageWrite { get; set; }
        public string PageWriteBase64 { get; set; }
        public string PageFoto { get; set; }
      
        // Kitap veritabanı id bilgisi
        public long BooksId { get; set; }


    }
}

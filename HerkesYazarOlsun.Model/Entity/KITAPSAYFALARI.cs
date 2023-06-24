using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.Model.Entity
{
   
    [Table(name: "KITAPSAYFALARI")]
    public class KITAPSAYFALARI : NewBaseEntity
    {
        public string SAYFAYAZISI { get; set; }
        public string SAYFAKAPAKFOTO { get; set; }
      
        // Kitap veritabanı id bilgisi
        public long KITAP_ID { get; set; }


    }
}

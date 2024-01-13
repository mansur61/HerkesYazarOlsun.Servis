using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "BooksDegerlendirme")]
    public class BooksDegerlendirme : BaseEntity
    {
        public string NAME { get; set; }
        public string EMAIL { get; set; }
        public string KONU { get; set; }
        public string ACIKLAMA { get; set; }
        public long BookId { get; set; }
        public long LoginUserId { get; set; }

        
        public int StarPuani { get; set; }
    }
}

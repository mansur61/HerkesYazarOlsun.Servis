using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "BooksComment")]
    public class BooksComment : NewBaseEntity
    {
        public string NAME { get; set; }
        public string EMAIL { get; set; }
        public string ACIKLAMA { get; set; }
        public long BookId { get; set; }
        public long LoginUserId { get; set; }

    }
}

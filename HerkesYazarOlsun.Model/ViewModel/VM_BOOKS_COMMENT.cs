using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.Model.ViewModel
{
    public class VM_BOOKS_COMMENT
    {

        public string? NAME { get; set; }
        public string? EMAIL { get; set; }
        public string? KONU { get; set; }
        public string? ACIKLAMA { get; set; }
        public long? BookId { get; set; }
        public long? LoginUserId { get; set; }
        public DateTime? CREATE_AT { get; set; }
        public long? ID { get; set; }
        public int StarPuani { get; set; }
    }
}

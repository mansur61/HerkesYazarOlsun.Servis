using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.Model.Entity
{
    
    public class VM_WriterFollow : BaseEntity
    {
        public int LoginUserId { get; set; }
        public int YazarId { get; set; }

       
        public int isFollow { get; set; }
    }
}

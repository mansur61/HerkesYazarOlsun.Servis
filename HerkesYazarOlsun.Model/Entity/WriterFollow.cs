using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "WriterFollow")]
    public class WriterFollow : BaseEntity
    {
        public int LoginUserId { get; set; }
        public int YazarId { get; set; }

        [DefaultValue(0)]
        public int isFollow { get; set; }
    }
}

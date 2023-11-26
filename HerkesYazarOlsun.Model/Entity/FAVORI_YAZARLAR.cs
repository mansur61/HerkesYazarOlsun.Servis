using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "FAVORI_YAZARLAR")]
    public class FAVORI_YAZARLAR : NewBaseEntity
    {
        public int LoginUserId { get; set; }
        public int YazarId { get; set; }

    }
}

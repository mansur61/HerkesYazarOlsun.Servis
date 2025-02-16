using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "CarouselDuyuru")]
    public class CarouselDuyuru : NewBaseEntity
    {
        public string ICERIK { get; set; }
        public string? URL { get; set; }
        public string? ICON { get; set; } 
        public DateTime? ICERIK_TARIHI { get; set; } 
    }


}

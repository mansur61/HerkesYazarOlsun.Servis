using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "Sponsorlar")]
    public class Sponsorlar : BaseEntity
    {
        public string SponsorAdi { get; set; }
    }
   
}

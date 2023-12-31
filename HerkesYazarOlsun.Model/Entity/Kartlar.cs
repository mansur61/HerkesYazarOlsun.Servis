using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "Kartlar")]
    public class Kartlar : NewBaseEntity
    {
        
        public long Cvv{ get; set; }
        public string KartUzerindekiIsim { get; set; }
       // public DateTime? KartTarihi { get; set; }
        public string KartTarihi { get; set; }
        public int KartTarihiAy { get; set; }
        public int KartTarihiYil { get; set; }
        public string KartNo { get; set; }
        
        public long OdemeId { get; set; }
        public long Tutar { get; set; }
        
    }
   
}

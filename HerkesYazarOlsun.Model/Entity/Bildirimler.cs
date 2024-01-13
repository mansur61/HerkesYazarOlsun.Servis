using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "Bildirimler")]
    public class Bildirimler : NewBaseEntity
    {

        public bool IsTakip { get; set; }
        public bool IsKitapYayin { get; set; }
        public bool IsKitapYorum { get; set; }
        public long? LoginUserId { get; set; }
    }
   
}

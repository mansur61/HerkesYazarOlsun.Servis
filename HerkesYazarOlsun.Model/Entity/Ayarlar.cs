using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "Ayarlar")]
    public class Ayarlar : NewBaseEntity
    {
        [DefaultValue(0)]
        public int? isDegisiklik { get; set; }
        public long LoginUserId { get; set; }   
       
        public long  UserDetailID { get; set; }       
        public long  ProfileID { get; set; }      
        public long  BildirimID { get; set; }
    }
   
}

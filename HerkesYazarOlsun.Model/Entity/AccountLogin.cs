using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "AccountLogin")]
    public class AccountLogin : NewBaseEntity
    {              
        public long LoginUserId { get; set; }
        public bool RememberLogin { get; set; }
        public string? email { get; set; }
        public string? sifre { get; set; }
        public string? benihatirla { get; set; }

        public bool? IsPersistent { get; set; }
        public DateTime? ExpiresUtc { get; set; }
        public bool? AllowRefresh { get; set; }
    }
   
}

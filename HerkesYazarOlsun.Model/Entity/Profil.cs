using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "Profil")]
    public class Profil : NewBaseEntity
    {

        public string? MimeType { get; set; }
        public string? ProfilResimURl { get; set; }
        public string? ProfilResimBase64 { get; set; }
        public string? ProfilResimName { get; set; }
        public long? LoginUserId { get; set; }
        public string? ProfilArkaplanResmi { get; set; }
        public string? ProfilArkaplanRenkKodu { get; set; }
    }
   
}

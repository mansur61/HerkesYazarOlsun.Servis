using System.ComponentModel.DataAnnotations.Schema;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "Profil")]
    public class Profil : NewBaseEntity
    {

        public string? MimeType { get; set; }
        public string? ProfilResimURl { get; set; }
        public string? ProfilResimBase64 { get; set; }
        public string? ProfilResimName { get; set; }
       
        public long? UserId { get; set; }
        public Users? User { get; set; }
        public string? ProfilArkaplanResmi { get; set; }
        public string? ProfilArkaplanRenkKodu { get; set; }
    }
   
}

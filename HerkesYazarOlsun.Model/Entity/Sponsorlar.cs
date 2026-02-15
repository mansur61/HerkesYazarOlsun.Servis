using System.ComponentModel.DataAnnotations.Schema;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "Sponsorlar")]
    public class Sponsorlar : NewBaseEntity
    {
        public string SponsorAdi { get; set; }
        public string URL { get; set; }
        public string ICON { get; set; }
    }
   
}

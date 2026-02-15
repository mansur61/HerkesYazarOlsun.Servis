using System.ComponentModel.DataAnnotations.Schema;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "OdemeSponsorlari")]
    public class OdemeSponsorlari : NewBaseEntity
    {
        
        public long KitapId { get; set; }
        public string NameSurname { get; set; }

        public long Tel { get; set; }
        public string Mail { get; set; }

        public string? Mesaj { get; set; }
        public long SponsorId { get; set; }
        public long LoginUserId { get; set; }
    }
   
}

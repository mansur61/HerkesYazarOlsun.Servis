using System.ComponentModel.DataAnnotations.Schema;


namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "UsersDetails")]
    public class UsersDetails : NewBaseEntity
    {
        public string? HAKKINDA { get; set; }       
        public DateTime? DogumTarihi { get; set; }
        public long? TEL { get; set; }
        public string? WebSite { get; set; }
        public string? TwitterLink { get; set; }
        public string? FacebookLink { get; set; }
        public string? LinkedinLink { get; set; }
        public string? InstagramLink { get; set; }
        public long? LoginUserId { get; set; }
        public Users? LoginUser { get; set; }

    }


}

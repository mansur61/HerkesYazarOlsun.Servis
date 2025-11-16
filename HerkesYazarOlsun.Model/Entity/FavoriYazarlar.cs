using System.ComponentModel.DataAnnotations.Schema;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "FavoriYazarlar")]
    public class FavoriYazarlar : NewBaseEntity
    {
        public long? LoginUserId { get; set; }
        public Users? LoginUser  { get; set; }
        public long? YazarId { get; set; }
        public Users? Yazar { get; set; }

    }
}

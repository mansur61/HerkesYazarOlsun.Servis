using System.ComponentModel.DataAnnotations.Schema;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "FavoriYazarlar")]
    public class FavoriYazarlar : NewBaseEntity
    {
        public int LoginUserId { get; set; }
        public int YazarId { get; set; }

    }
}

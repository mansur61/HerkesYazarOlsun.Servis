using System.ComponentModel.DataAnnotations.Schema;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "FavoriBooks")]
    public class FavoriBooks : NewBaseEntity
    {
        [ForeignKey(nameof(Book))]
        public long? BookId { get; set; }
        public Books? Book { get; set; }

        [ForeignKey(nameof(User))]
        public long? UserId { get; set; }
        public Users? User { get; set; }
    }
}

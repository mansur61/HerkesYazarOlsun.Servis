using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "WriterFollow")]
    public class WriterFollow : BaseEntity
    {
        public long? LoginUserId { get; set; }
        public Users? LoginUsers { get; set; }
        public long? YazarId { get; set; }
        public Users? YazarUsers { get; set; }

        [DefaultValue(0)]
        public int isFollow { get; set; }
    }
}

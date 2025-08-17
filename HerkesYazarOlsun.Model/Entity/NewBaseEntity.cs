
using System.ComponentModel.DataAnnotations;

namespace HerkesYazarOlsun.Model.Entity
{
   
    public class NewBaseEntity : IEntity
    {
        [Key]
        public long ID { get; set; }

        public DateTime? CREATE_AT { get; set; }

        public long? USER_CREATED_ID { get; set; }
        public string? OLUSTURAN_EMAIL { get; set; }

        public long? IS_MODIFIED { get; set; }

        public DateTime? MODIFIED_AT { get; set; }

        public long? USER_MODIFIED_ID { get; set; }

        public string? USER_MODIFIED_MAIL { get; set; }

        public long? IS_DELETED { get; set; } = 0;
    }
}

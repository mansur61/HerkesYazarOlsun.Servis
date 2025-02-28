
namespace HerkesYazarOlsun.Model.ViewModel
{
    public class VM_CAROUSEL_DUYURU
    {
        public string ICERIK { get; set; }
        public string? URL { get; set; }
        public string? ICON { get; set; }
        public DateTime? ICERIK_TARIHI { get; set; }
        public long ID { get; set; }

        public string? RENK { get; set; }
        public DateTime? CREATE_AT { get; set; }

        public long? USER_CREATED_ID { get; set; }
        public string? OLUSTURAN_EMAIL { get; set; }

        public long IS_MODIFIED { get; set; }

        public DateTime? MODIFIED_AT { get; set; }

        public long USER_MODIFIED_ID { get; set; }

        public string? USER_MODIFIED_MAIL { get; set; }

        public long IS_DELETED { get; set; }
    }
}

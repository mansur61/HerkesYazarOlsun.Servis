 
namespace HerkesYazarOlsun.Model.ViewModel
{
    public class VM_SPONSORLAR
    {
        public string SponsorAdi { get; set; }
        public long ID { get; set; }
        public long tck { get; set; } 
        public DateTime? CREATE_AT { get; set; }

        public long? USER_CREATED_ID { get; set; }
        public string? OLUSTURAN_EMAIL { get; set; }

        public long? IS_MODIFIED { get; set; }

        public DateTime? MODIFIED_AT { get; set; }

        public long? USER_MODIFIED_ID { get; set; }

        public string? USER_MODIFIED_MAIL { get; set; }

        public long? IS_DELETED { get; set; }
        public List<VM_SPONSORLAR> SponsorlarList { get; set; }
    }
}


namespace HerkesYazarOlsun.Model.ViewModel
{
    public class VM_LOGIN
    {
        public bool RememberLogin { get; set; }
        public long LoginUserId { get; set; }
        
        public string? email { get; set; }
        public string? sifre { get; set; }
        public string? benihatirla { get; set; }

        public bool IsPersistent { get; set; }
        public DateTime? ExpiresUtc { get; set; }
        public bool AllowRefresh { get; set; }
        


    }
}

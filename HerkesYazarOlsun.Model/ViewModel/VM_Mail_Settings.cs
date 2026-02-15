 

namespace HerkesYazarOlsun.Model.ViewModel
{
    public class VM_Mail_Settings
    {
        public int? Port { get; set; }
        public Boolean EnableSSL { get; set; } = true;
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Host { get; set; }
        public string? FromEmail { get; set; }
        public string? Subject { get; set; }
    }
}

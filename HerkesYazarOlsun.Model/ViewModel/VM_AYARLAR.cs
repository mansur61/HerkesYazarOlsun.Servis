

using HerkesYazarOlsun.Model.Entity;
using Microsoft.AspNetCore.Http;

namespace HerkesYazarOlsun.Model.ViewModel
{
    public class VM_AYARLAR
    {
        public int? isDegisiklik { get; set; }
        public long LoginUserId { get; set; }
        public long UserDetailId { get; set; }
         public List<IFormFile>? dosyalar { get; set; }
        //public List<IFormFile> dosyalar { get; set; } = new List<IFormFile>();
        public long ProfileId { get; set; }
        public long BildirimId { get; set; }
        public  UsersDetails UserDetail { get; set; }
        public  VM_PROFILE Profile { get; set; }
        public Users User { get; set; }
        public Bildirimler Bildirim { get; set; }
    }
}

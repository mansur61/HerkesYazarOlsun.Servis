using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.Model.ViewModel
{

    public class VM_USERS
    {
        public static VM_USERS MapToVM(Users user)
        {
            if (user == null) return null;

            var vmUser = new VM_USERS
            {
                NAME = user.NAME,
                SURNAME = user.SURNAME,
                USERNAME = user.USERNAME,
                EMAIL = user.EMAIL,
                TELNO = user.TELNO,
                isSozlesmeOnay = user.isSozlesmeOnay,
                Profile = user.Profil == null ? null : new VM_PROFILE
                {
                    ID = user.Profil.ID,
                    ProfilArkaplanRenkKodu = user.Profil.ProfilArkaplanRenkKodu,
                    ProfilArkaplanResmi = user.Profil.ProfilResimBase64,
                    ProfilResimName = user.Profil.ProfilResimName,
                    ProfilResimURl = user.Profil.ProfilResimURl,
                    MimeType = user.Profil.MimeType,
                    LoginUserId = user.Profil.LoginUserId
                }
            };
            return vmUser;
        }

        public VM_PROFILE? Profile { get; set; }
        public long ID { get; set; }
        public string? NAME { get; set; }
        public string? SURNAME { get; set; }
        public int? isSozlesmeOnay { get; set; }
        public string? USERNAME { get; set; }       
        public string? EMAIL { get; set; }
        public string? TELNO { get; set; } 
        public VM_Stars? Stars { get; set; }
        public List<VM_WriterFollow>?  WriterFollowList { get; set; }
        public List<VM_WriterStars>? WriterStarsList { get; set; }        
        public string? PASSWORD { get; set; }
        public int isEmail { get; set; } 
        public int isTelno { get; set; }  
        public long YAZAR_ID { get; set; }

    }

}

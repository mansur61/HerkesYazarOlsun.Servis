using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.Model.ViewModel
{

    public class VM_USERS
    {
        public static VM_USERS MapToVM(Users user)
        {
            if (user == null) return null;

            return new VM_USERS
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
                    ProfilArkaplanResmi = user.Profil.ProfilArkaplanResmi,  
                    ProfilResimBase64 = user.Profil.ProfilResimBase64,
                    ProfilResimName = user.Profil.ProfilResimName,
                    ProfilResimURl = user.Profil.ProfilResimURl,
                    MimeType = user.Profil.MimeType,
                    LoginUserId = user.Profil.LoginUserId                        
                }
            };
        }

        public VM_PROFILE? Profile { get; set; }
        public long ID { get; set; }
        public string? NAME { get; set; }
        public string? SURNAME { get; set; }
        public int? isSozlesmeOnay { get; set; }
        public string? USERNAME { get; set; }
        public int bolum { get; set; }
        public string? EMAIL { get; set; }
        public string? TELNO { get; set; }
        public VM_PAGINATION_BUTTON? vM_PAGINATION_BUTTONS { get; set; }
        public VM_Stars? Stars { get; set; }
        public string? yazarSliderYometimAdi { get; set; }
        public VM_WriterFollow? vMWriterFollow { get; set; }
        public string? PASSWORD { get; set; }
        public int isEmail { get; set; }
        public string? Tip { get; set; }
        public int isTelno { get; set; }
        public int kalan { get; set; }
        public int sliderdaGosterilecekKayit { get; set; }
        public List<Users>? UsersList { get; set; }
        public List<VM_USERS>? VMUsersList { get; set; }       
        public long YAZAR_ID { get; set; }
        
        public  int Start { get; set; }

       
        public int End { get; set; }
       
    }

}

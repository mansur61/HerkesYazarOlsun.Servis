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
                ID = user.ID,
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
                    LoginUserId = user.Profil.UserId
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

        public ICollection<BooksStars>? BooksStarsList { get; set; } // yıldız verilen kitaplar
        public ICollection<FavoriYazarlar>? FavoriYazarlarList { get; set; }
        public ICollection<WriterFollow>? WriterFollowLoginList { get; set; } // beni takip edenler
        public ICollection<WriterFollow>? WriterFollowYazarList { get; set; } // takip edilenler

        public ICollection<WriterStars>? WriterStarsLoginList { get; set; } // bana yıldız verenler
        public ICollection<WriterStars>? WriterStarsYazarList { get; set; } // yıldız verdiklerim

        public string? PASSWORD { get; set; }
        public int isEmail { get; set; } 
        public int isTelno { get; set; }  
        public long YAZAR_ID { get; set; }

    }

}

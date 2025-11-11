
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;


namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "Users")]
    public class Users : NewBaseEntity
    {
        public string? NAME { get; set; }
        public string? SURNAME { get; set; }
        public string? USERNAME { get; set; }
        public string? EMAIL { get; set; }
        public string? TELNO { get; set; }

        [DefaultValue(0)]
        public int isEmail { get; set; }
        [DefaultValue(0)]
        public int isTelno { get; set; }
        public string? PASSWORD { get; set; }

        public int? isSozlesmeOnay { get; set; }
         
        public Profil? Profil { get; set; }
        public ICollection<BooksStars>? BooksStarsList { get; set; } // yıldız verilen kitaplar
        public ICollection<FavoriYazarlar>? FavoriYazarlarList { get; set; }
        public ICollection<WriterFollow>? WriterFollowLoginList { get; set; } // beni takip edenler
        public ICollection<WriterFollow>? WriterFollowYazarList { get; set; } // takip edilenler

        public ICollection<WriterStars>? WriterStarsLoginList { get; set; } // bana yıldız verenler
        public ICollection<WriterStars>? WriterStarsYazarList { get; set; } // yıldız verdiklerim
    }


}

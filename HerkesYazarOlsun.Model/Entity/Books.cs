using System.ComponentModel.DataAnnotations.Schema;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "Books")]
    public class Books : NewBaseEntity
    {
        public string Name { get; set; }
        public string ONSOZ { get; set; }
        public string ONKAPAKFOTO { get; set; }
        public string ARKAKAPAKFOTO { get; set; }
        public string ONKAPAKFOTOPATH { get; set; }
        public string ARKAKAPAKFOTOPATH { get; set; }
        public string ARKAKAPAKYAZISI { get; set; }
        public bool TAMAMLANDIMI { get; set; }
        public long? YazarId { get; set; }
        public Users? User { get; set; }
        public bool YAYINDAMI { get; set; }
        public int? CategoriId { get; set; }
        public Category? Categories { get; set; }
        public int? BookStarId { get; set; }  
        public ICollection<BooksStars>? BooksStars { get; set; }

        public int? FavoriBookId { get; set; }
        public ICollection<FavoriBooks>? FavoriBooks { get; set; }
        
        public int? YayinAyarId { get; set; }
        public YayinAyarlari? BookYayinAyari { get; set; }        
        public ICollection<BooksPages>? BooksPageList { get; set; }
        public ICollection<BooksComment>? BooksComments { get; set; }
        public ICollection<BooksDegerlendirme>? BooksDegerlendirme { get; set; }
        
    }
   
}

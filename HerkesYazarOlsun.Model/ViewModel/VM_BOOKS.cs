using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.Model.ViewModel
{
    public class VM_BOOKS
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string ONSOZ { get; set; }
        public string ONKAPAKFOTO { get; set; }
        public string ARKAKAPAKFOTO { get; set; }
        public string ONKAPAKFOTOPATH { get; set; }
        public string ARKAKAPAKFOTOPATH { get; set; }
        public string ARKAKAPAKYAZISI { get; set; }
        public bool TAMAMLANDIMI { get; set; }

        public int? YazarId { get; set; }
        public int? LoginUserId { get; set; }
        public Users? User { get; set; }
        public bool YAYINDAMI { get; set; }
        public int? CategoriId { get; set; }
        public VM_CATEGORI? Categories { get; set; }
        public int? YayinAyarId { get; set; } 
        public VM_BOOK_ISTATISTIKLER? BookYayinAyari { get; set; } 
        public List<VM_BOOKS_COMMENT>? BooksComments { get; set; }
        public List<VM_BOOKS_DEGERLENDIRME>? BooksDegerlendirme { get; set; }
        public List<VM_BOOKS_PAGES>? BooksPageList { get; set; }
        public VM_Stars? Stars { get; set; }
        public VM_BOOK_ISTATISTIKLER? iSTATISTIK { get; set; }
        public int? BooksStarsId { get; set; }
        public List<VM_BOOK_STAR>? BooksStars { get; set; }
        public int? FavoriBookId { get; set; }
        public List<VM_FAVORI_BOOK>? FavoriBooks { get; set; }
    }
}

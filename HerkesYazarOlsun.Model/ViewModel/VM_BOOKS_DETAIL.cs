using Microsoft.AspNetCore.Http;

namespace HerkesYazarOlsun.Model.ViewModel
{
    public class VM_BOOKS_DETAIL
    {
        public int? sliderdaGosterilecekKayit { get; set; }
        public int? kalan { get; set; }
        public int? bolum { get; set; }
        public string? kitap_id { get; set; }
        public string? FDileName { get; set; }        
        public bool IsWowBookEdit { get; set; } = false;
        public string? profilKitapTuru { get; set; }
        public int? IlgiiSayfaSayisi { get; set; }
        public string? kitapSliderYometimAdi { get; set; }
        public bool? isWordPDF { get; set; }
        public bool? isAnaSayfa { get; set; }
        public bool? isYazmayaDevamEt { get; set; }
        public int? pdfVeyaWord { get; set; }
        public bool? isPdfVeyaWordTamalama { get; set; }
        public bool? isTamalama { get; set; }
        public VM_PAGINATION_BUTTON? vM_PAGINATION_BUTTONS { get; set; } 
        public VM_BOOK_ISTATISTIKLER? iSTATISTIK { get; set; } 
        public int? Start { get; set; }
        public int? End { get; set; }
        public string? Tip { get; set; }
        public string? AktarilanDosya { get; set; } 
        public List<IFormFile>? dosyalar { get; set; }
        public List<VM_BOOKS>? VMBooksList { get; set; }
        public VM_BOOKS? BookModel { get; set; }
        public VM_BOOKS_PAGES? BookPagesModel { get; set; }        
        public List<VM_CATEGORI>? Katergoriler { get; set; }
    }
}

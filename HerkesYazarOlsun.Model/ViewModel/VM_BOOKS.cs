using HerkesYazarOlsun.Model.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.Model.ViewModel
{
    public class VM_BOOKS
    {
        public long ID { get; set; }
        public int sliderdaGosterilecekKayit { get; set; }
        public int kalan { get; set; }
        public int bolum { get; set; }
        public string profilKitapTuru { get; set; }
        public long YAZAR_ID { get; set; }
        public long YazarId { get; set; }
        public int IlgiiSayfaSayisi { get; set; }
        public long LoginUserId { get; set; }
        public string Name { get; set; }
        public string FDileName { get; set; }

        public string kitapSliderYometimAdi { get; set; }
        public bool isWordPDF { get; set; }
        public int pdfVeyaWord { get; set; }
        public bool? isPdfVeyaWordTamalama { get; set; }
        
        public VM_PAGINATION_BUTTON vM_PAGINATION_BUTTONS { get; set; }
        public VM_Stars  Stars{ get; set; }
        public DateTime? CREATE_AT { get; set; }
        public  int Start { get; set; }
        public int End { get; set; }
        public string Tip { get; set; }
        public string ONSOZ { get; set; }
        public string ONKAPAKFOTO { get; set; }
        public string ARKAKAPAKFOTO { get; set; }
        public string ARKAKAPAKYAZISI { get; set; }
        public string KITAPSAYFAFOTO { get; set; }
        public string SAYFAYAZI { get; set; }
        public List<IFormFile>? dosyalar { get; set; }
        public string SAYFAYAZIBASE64 { get; set; }
        public long CategoriId { get; set; }
        public List<Books> BooksList { get; set; }
        public List<VM_BOOKS> VMBooksList { get; set; }
        public List<VM_BOOKS_PAGES> BooksPageList { get; set; }
    }

}

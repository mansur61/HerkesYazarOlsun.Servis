using HerkesYazarOlsun.Model.Entity;
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
        
        public string Name { get; set; }    
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
        public long CategoriId { get; set; }
        public List<Books> BooksList { get; set; }
        public List<VM_BOOKS> VMBooksList { get; set; }
        public List<VM_BOOKS_PAGES> BooksPageList { get; set; }
    }

}

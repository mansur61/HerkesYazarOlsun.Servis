using HerkesYazarOlsun.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.Model.ViewModel
{
    public class VM_ARAMA_SONUC
    {

        public VM_BOOKS vmBook { get; set; }
        public int kalan { get; set; }
        public int sliderdaGosterilecekKayit { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public string PageWrite { get; set; }
        public string PageFoto { get; set; }

        // Kitap veritabanı id bilgisi
        public long BooksId { get; set; }

        public string SURNAME { get; set; }

        public string EMAIL { get; set; }
        public string TCKNO { get; set; }

        public string PASSWORD { get; set; }

        public string Name { get; set; }
        public string ONSOZ { get; set; }
        public string ONKAPAKFOTO { get; set; }
        public string ARKAKAPAKFOTO { get; set; }
        public string ARKAKAPAKYAZISI { get; set; }
        public bool TAMAMLANDIMI { get; set; }

        public bool YAYINDAMI { get; set; }
        public long CategoriId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.Model.ViewModel
{
    public class VM_BOOKS_PAGES
    {
        public long ID { get; set; }
        public string PageWrite { get; set; }
        public string PageFoto { get; set; }

        // Kitap veritabanı id bilgisi
        public long BooksId { get; set; }
    }
}

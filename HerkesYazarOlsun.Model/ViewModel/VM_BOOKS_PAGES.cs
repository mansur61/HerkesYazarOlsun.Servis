namespace HerkesYazarOlsun.Model.ViewModel
{
    public class VM_BOOKS_PAGES
    {
        public long ID { get; set; }
        public string? PageWrite { get; set; }
        public string? PageFoto { get; set; }
        public string PageWriteBase64 { get; set; }
        public bool isWordPDF { get; set; } 
        // Kitap veritabanı id bilgisi
        public long BooksId { get; set; }
    }

}

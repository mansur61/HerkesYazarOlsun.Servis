using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
namespace HerkesYazarOlsun.BLL.Concrete
{
    public class BooksDegerlendirmeBll : IBooksDegerlendirmeService
    {

        IBooksDegerlendirmeDal booksDegerlendirmeDal;
        public BooksDegerlendirmeBll(IBooksDegerlendirmeDal booksDegerlendirmeDal)
        {
            this.booksDegerlendirmeDal = booksDegerlendirmeDal;
        }
         
        public BooksDegerlendirme? Ekle(BooksDegerlendirme ayar,string? mail)
        {
            return booksDegerlendirmeDal.Add(ayar);  
        }

        public BooksDegerlendirme? Guncelle(BooksDegerlendirme ayar, long tck)
        {
           return booksDegerlendirmeDal.Add(ayar);
        }
        public List<BooksDegerlendirme> GetList(long kitapId)
        {
            return booksDegerlendirmeDal.GetList(p => p.BookId == kitapId).ToList(); ;
        }
    }
}

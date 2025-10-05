
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface IBooksDegerlendirmeService
    {
        BooksDegerlendirme? Guncelle(BooksDegerlendirme usr, long tck);
        BooksDegerlendirme? Ekle(BooksDegerlendirme usr, string? mail);

        List<BooksDegerlendirme> GetList(long kitapId);
    }

}

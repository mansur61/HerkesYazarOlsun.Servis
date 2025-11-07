
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface IBooksStarsService
    {
        BooksStars? Guncelle(BooksStars usr, long tck);
        BooksStars? Ekle(BooksStars usr, string? mail);
        BooksStars? Get(long LoginUserId, long YazarId);
        List<BooksStars> GetBooksStarsByuserId(long userId);       

    }

}

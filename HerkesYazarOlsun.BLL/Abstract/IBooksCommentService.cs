
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface IBooksCommentService
    {
        BooksComment? Guncelle(BooksComment ayar, string? mail);
        BooksComment? Add(BooksComment ayar, long tck);

        List<BooksComment> GetList(long kitapId);
    }

}

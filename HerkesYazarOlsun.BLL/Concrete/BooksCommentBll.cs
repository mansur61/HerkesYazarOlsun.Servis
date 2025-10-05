using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Concrete;
using HerkesYazarOlsun.Model.Entity;
namespace HerkesYazarOlsun.BLL.Concrete
{
    public class BooksCommentBl : IBooksCommentService
    {

        IBooksCommentDal BooksCommentDal;
        public BooksCommentBl(IBooksCommentDal BooksCommentDal)
        {
            this.BooksCommentDal = BooksCommentDal;
        }
         
        public BooksComment? Guncelle(BooksComment ayar,string? mail)
        {
            return BooksCommentDal.Guncelle(ayar,mail);  
        }

        public BooksComment? Add(BooksComment ayar, long tck)
        {
           return BooksCommentDal.Add(ayar, tck);
        }

        public List<BooksComment> GetList(long kitapId)
        {
            return BooksCommentDal.GetAllQueryable(p => p.BookId == kitapId).ToList();
        }

    }
}

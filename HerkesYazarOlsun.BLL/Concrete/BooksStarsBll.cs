using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
namespace HerkesYazarOlsun.BLL.Concrete
{
    public class BooksStarsBll : IBooksStarsService
    {

        IBooksStarsDal starsDal;
        public BooksStarsBll(IBooksStarsDal starsDal)
        {
            this.starsDal = starsDal;
        }
         
        public BooksStars? Ekle(BooksStars ayar,string? mail)
        {
            return starsDal.Add(ayar);  
        }

        public BooksStars? Guncelle(BooksStars ayar, long tck)
        {
           return starsDal.Add(ayar);
        }
        public BooksStars? Get(long LoginUserId,long YazarId)
        {
            var sonuc = starsDal.Get(p => p.LoginUserId == LoginUserId);
            return sonuc;
        }
        
    }
}

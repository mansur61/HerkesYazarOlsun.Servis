using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
namespace HerkesYazarOlsun.BLL.Concrete
{
    public class WriterStarsBll : IWriterStarsService
    {

        IWriterStarsDal starsDal;
        public WriterStarsBll(IWriterStarsDal starsDal)
        {
            this.starsDal = starsDal;
        }
         
        public WriterStars? Ekle(WriterStars ayar,string? mail)
        {
            return starsDal.Add(ayar);  
        }

        public WriterStars? Guncelle(WriterStars ayar, long tck)
        {
           return starsDal.Add(ayar);
        }
        public WriterStars? Get(long LoginUserId,long YazarId)
        {
            var sonuc = starsDal.Get(p => p.LoginUserId == LoginUserId && p.YazarId == YazarId);
            return sonuc;
        }
        
    }
}

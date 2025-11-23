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

        public   void Guncelle(WriterStars ayar, long tck)
        {
             starsDal.Update(ayar);
        }
        public WriterStars? GetTrackingYok(long LoginUserId,long YazarId)
        {
            var sonuc = starsDal.GetTrackingYok(p => p.LoginUserId == LoginUserId && p.YazarId == YazarId);
            return sonuc;
        }

        public WriterStars? Get(long LoginUserId, long YazarId)
        {
            var sonuc = starsDal.Get(p => p.LoginUserId == LoginUserId && p.YazarId == YazarId);
            return sonuc;
        }
        public List<WriterStars> GetWriterStarsByuserId(long userId)
        {
            return starsDal.GetList(p => p.LoginUserId == userId).ToList();
        }


    }
}

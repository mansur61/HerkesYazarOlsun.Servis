using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
namespace HerkesYazarOlsun.BLL.Concrete
{
    public class WriterFollowBll : IWriterFollowService
    {

        IWriterFollowDal yazarDal;
        public WriterFollowBll(IWriterFollowDal yazarDal)
        {
            this.yazarDal = yazarDal;
        }
         
        public WriterFollow? Ekle(WriterFollow ayar,string? mail)
        {
            return yazarDal.Add(ayar);  
        }

        public WriterFollow? Guncelle(WriterFollow ayar, long tck)
        {
           return yazarDal.Add(ayar);
        }
        public WriterFollow? Get(long LoginUserId)
        {
            var sonuc = yazarDal.Get(p => p.LoginUserId == LoginUserId);
            return sonuc;
        }
        
    }
}

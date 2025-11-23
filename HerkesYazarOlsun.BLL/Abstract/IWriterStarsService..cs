
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface IWriterStarsService
    {
        void Guncelle(WriterStars usr, long tck);
        WriterStars? GetTrackingYok(long LoginUserId, long YazarId);
        WriterStars? Ekle(WriterStars usr, string? mail);
        WriterStars? Get(long LoginUserId, long YazarId);
        List<WriterStars> GetWriterStarsByuserId(long userId);
    }

}

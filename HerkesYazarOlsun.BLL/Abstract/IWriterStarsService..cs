
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface IWriterStarsService
    {
        WriterStars? Guncelle(WriterStars usr, long tck);
        WriterStars? Ekle(WriterStars usr, string? mail);
        WriterStars? Get(long LoginUserId, long YazarId);
    }

}

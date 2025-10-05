
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface IWriterFollowService
    {
        WriterFollow? Guncelle(WriterFollow usr, long tck);
        WriterFollow? Ekle(WriterFollow usr, string? mail);
        WriterFollow? Get(long LoginUserId);
    }

}


using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface IBooksService
    {
        List<Books> GetBooksList();
        Books GetBooks(long id);

        Books PostSaveBook(Books books);
       
        
    }
}

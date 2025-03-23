using HerkesYazarOlsun.DataLayer.Repo; 
using HerkesYazarOlsun.DataLayer.Repository;
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.DataLayer
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        IRepo<T> Repo<T>() where T : NewBaseEntity;

        int Save();
        void OpenTransaction();
        void CloseTransaction();
    }
}

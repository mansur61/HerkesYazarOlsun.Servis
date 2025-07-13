using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.DataLayer.Repo
{ 
    public interface ISqlRepo<T> : IRepo<T> where T : NewBaseEntity
    { 
    }

}

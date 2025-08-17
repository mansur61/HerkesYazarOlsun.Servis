using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.DataLayer.Repo
{
    public interface INpgsqlRepo<T> : IRepo<T> where T : NewBaseEntity
    { 
    }

}

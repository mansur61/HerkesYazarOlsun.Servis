using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
namespace HerkesYazarOlsun.BLL.Concrete
{
    public class TaleplerBll : ITaleplerService
    {

        ITaleplerDal _taleplerDal;
        public TaleplerBll(ITaleplerDal _taleplerDal)
        {
            this._taleplerDal = _taleplerDal;
        }
 

        public Talepler? Add(Talepler sps)
        {
            return _taleplerDal.Add(sps); 
        }

         

    }
}

using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Repo;
using HerkesYazarOlsun.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.DataLayer.Concrete.EntityFramework
{
    public class FavorilerDal : Repo<FAVORILER>, IFavorilerDal
    {
    }
}

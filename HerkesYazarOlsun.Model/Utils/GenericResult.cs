using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.Model.Utils
{
    public class GenericResult<T>
    {
        public List<T> data { get; set; }
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public object Result { get; set; }
    }
}

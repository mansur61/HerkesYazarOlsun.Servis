using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.Model.ViewModel
{
    public class VM_SPONSORLAR
    {
        public string SponsorAdi { get; set; }
        public long ID { get; set; }
        public long tck { get; set; }

        public List<VM_SPONSORLAR> SponsorlarList { get; set; }
    }
}

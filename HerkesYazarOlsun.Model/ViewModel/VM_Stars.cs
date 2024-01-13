using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.Model.ViewModel
{
    public class VM_Stars
    {
        public int  EnFazlaSitar { get; set; }
        public string? HangiStar { get; set; }
        public int BirStarToplam { get; set; }
        public string? BirStar { get; set; }

        public int IkiStarToplam { get; set; }
        public string? IkiStar { get; set; }

        public int UcStarToplam { get; set; }
        public string? UcStar { get; set; }

        public int DortStarToplam { get; set; }
        public string? DortStar { get; set; }

        public bool isToplam { get; set; }
        public int BesStarToplam { get; set; }
        public string? BesStar { get; set; }

    }
}

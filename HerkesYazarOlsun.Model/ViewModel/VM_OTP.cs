using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.Model.ViewModel
{
    public class VM_OTP
    {
        public string? baslik { get; set; }
        public string? alt_baslik { get; set; }
        public string? tip { get; set; }
        public string? telno { get; set; }
        public string? mail { get; set; }

        public string? emailKod { get; set; }
        public string? smsKod { get; set; }
    }
}

using HerkesYazarOlsun.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.Model.ViewModel
{
    public class VM_USERS
    {
        public Profil? Profile { get; set; }
        public long ID { get; set; }
        public string? NAME { get; set; }
        public string? SURNAME { get; set; }
        public string? USERNAME { get; set; }
        public int bolum { get; set; }
        public string? EMAIL { get; set; }
        public string? TELNO { get; set; }
        public VM_PAGINATION_BUTTON? vM_PAGINATION_BUTTONS { get; set; }
        public VM_Stars Stars { get; set; }
        public string yazarSliderYometimAdi { get; set; }
        public VM_WriterFollow vMWriterFollow { get; set; }
        public string? PASSWORD { get; set; }
        public int isEmail { get; set; }
        public string Tip { get; set; }
        public int isTelno { get; set; }
        public int kalan { get; set; }
        public int sliderdaGosterilecekKayit { get; set; }
        public List<Users>? UsersList { get; set; }
        public List<VM_USERS>? VMUsersList { get; set; }
       
        public long YAZAR_ID { get; set; }
        
        public  int Start { get; set; }

       
        public int End { get; set; }
       
    }

}

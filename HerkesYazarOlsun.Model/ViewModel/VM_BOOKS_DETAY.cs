using HerkesYazarOlsun.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.Model.ViewModel
{
    public class VM_BOOKS_DETAY
    {
       
        public VM_Stars Stars { get; set; }

        public VM_BOOKS Vm_Book { get; set; }

        public List<VM_BOOKS_DEGERLENDIRME> Vm_Book_Degerlendirme_List { get; set; }

        public List<VM_BOOKS_COMMENT> Vm_Book_Comments { get; set; }
    }

}

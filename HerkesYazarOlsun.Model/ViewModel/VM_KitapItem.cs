using HerkesYazarOlsun.Model.ViewModel;

namespace HerkesYazarOlsun.Model.ViewModel
{
    public class VM_KitapItem
    {
        public VM_BOOKS? Book { get; set; }   
        public string Tip { get; set; }
        public int? LoginUserId { get; set; }
        public string IsGozlemci { get; set; }
        public bool? isAnaSayfa { get; set; }
    }
}
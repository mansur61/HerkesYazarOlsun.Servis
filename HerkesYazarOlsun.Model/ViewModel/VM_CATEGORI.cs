using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.Model.ViewModel
{
    public class VM_CATEGORI
    {
        public int? ID { get; set; } 
        public string Name { get; set; }
        public CategoryYayinAyarlari? CategoryYayinAyarlari { get; set; }
    }
}

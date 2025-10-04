using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.Model.ViewModel
{
    
    public class VM_WriterFollow : BaseEntity
    {
        public int LoginUserId { get; set; }
        public int YazarId { get; set; }
        public int isFollow { get; set; }
    }
}

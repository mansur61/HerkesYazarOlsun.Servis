namespace HerkesYazarOlsun.Model.ViewModel
{
    public class VM_USERS_DETAIL
    {         
        public VM_PAGINATION_BUTTON? vM_PAGINATION_BUTTONS { get; set; } 
        public string? yazarSliderYometimAdi { get; set; }      
        public string? PASSWORD { get; set; }
        public int isEmail { get; set; }
        public string? Tip { get; set; }
        public int bolum { get; set; } 
        public int kalan { get; set; }
        public int sliderdaGosterilecekKayit { get; set; } 
        public List<VM_USERS>? VMUsersList { get; set; }        
        public  int Start { get; set; }
        public int End { get; set; }
       
    }

}

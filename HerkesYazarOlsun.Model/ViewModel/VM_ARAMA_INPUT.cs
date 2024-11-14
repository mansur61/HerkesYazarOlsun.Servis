namespace HerkesYazarOlsun.Model.ViewModel
{
    public class VM_ARAMA_INPUT
    {
        public string? YAZAR_ADI { get; set; }
        public string? Tip { get; set; }
        public int listelenecek_kayit_sayisi { get; set; }
        public string? KITAP_ADI { get; set; }
        public bool? BitenKitaplar { get; set; }
        public bool? FavoriKitaplar { get; set; }
        public bool? YayinlananKitaplar { get; set; }
        public int? tarihCeck { get; set; }
        public long? kategoriId { get; set; }
        public long? yazarIId { get; set; }
        public long? siralama { get; set; }
        public string? profilKitapTuru { get; set; }
        public bool? FavoriYazarlar { get; set; }
        public bool? DevamEdenKitaplar { get; set; }
    }
}

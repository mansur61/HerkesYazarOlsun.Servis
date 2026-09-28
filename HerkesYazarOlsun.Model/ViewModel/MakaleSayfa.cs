namespace HerkesYazarOlsun.Model.ViewModel;
public class MakaleOzet
{
    public Guid Id { get; set; }
    public long YazarId { get; set; }
    public string Yazar { get; set; } = "";
    public string Baslik { get; set; } = "";
    public DateTimeOffset? YayinTarihi { get; set; }
}
public class MakaleSayfa
{
    public List<MakaleOzet> Items { get; set; } = [];
    public bool HasMore { get; set; }
    public int Page { get; set; }
}

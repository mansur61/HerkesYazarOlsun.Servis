namespace HerkesYazarOlsun.Model.Entity;
public class Makale
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public long YazarId { get; set; }
    public string Yazar { get; set; } = "";
    public string Baslik { get; set; } = "";
    public string Metin { get; set; } = "";
    public string Uzanti { get; set; } = "";
    public DateTimeOffset OlusturmaTarihi { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? YayinTarihi { get; set; }
}
public class MakaleBelge
{
    public Guid Id { get; set; }
    public byte[] Icerik { get; set; } = [];
}

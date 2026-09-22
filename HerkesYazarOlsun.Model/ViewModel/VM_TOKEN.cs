namespace HerkesYazarOlsun.Model.ViewModel
{
    /// <summary>Login ve RefreshToken endpoint'lerinin dönüş modeli.</summary>
    public class VM_TOKEN_RESPONSE
    {
        public string AccessToken  { get; set; } = "";
        public string RefreshToken { get; set; } = "";
        public DateTime ExpiresAt  { get; set; }
        public object?  User       { get; set; }
    }

    /// <summary>Token yenileme isteği.</summary>
    public class VM_REFRESH_TOKEN_REQUEST
    {
        public string RefreshToken { get; set; } = "";
    }
}

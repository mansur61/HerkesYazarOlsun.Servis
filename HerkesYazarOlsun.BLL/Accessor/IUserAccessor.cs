using Microsoft.AspNetCore.Http;

namespace HerkesYazarOlsun.BLL.Accessor
{
    public interface IUserAccessor
    {
        IHttpContextAccessor _accessor { get; }

        long YETKILITCNO { get; }

        long TEL_NO { get; }

        string MAIL { get; }

        string ADISOYADI { get; }
      
        int? UYGULAMA_ID { get; }

        string IP { get; }

        
    }
}

using Microsoft.AspNetCore.Http;

namespace HerkesYazarOlsun.BLL.Accessor
{
    public interface IUserAccessor
    {
        IHttpContextAccessor _accessor { get; }

        long YETKILITCNO { get; }

        long USER_BIRIM_ID { get; }

        string MAIL { get; }

        string ADISOYADI { get; }

        long? BIRIMID { get; }
        int? UYGULAMA_ID { get; }

        string IP { get; }

        long? BIRIMSEVIYE { get; }
    }
}

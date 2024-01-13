using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.DataLayer.Abstract;
using Microsoft.AspNetCore.Http;

namespace HerkesYazarOlsun.BLL.Accessor
{
    public class HttpUserAccessor : IUserAccessor
    {
        public readonly IHttpContextAccessor accessor;

        public HttpUserAccessor(IHttpContextAccessor accessor)
        {
            this.accessor = accessor;
        }

        public IHttpContextAccessor _accessor
        {
            get
            {
                return accessor;
            }
        }

        public long YETKILITCNO
        {
            get
            {
                if (_accessor.HttpContext != null)
                {
                    var headerValue = _accessor.HttpContext.Request.Headers["tckimlikno"];
                    if (!string.IsNullOrEmpty(headerValue))
                    {
                        return Convert.ToInt64(headerValue);
                    }
                }
                return 0;
            }
        }

        public long TEl_NO
        {
            get
            {
                if (_accessor.HttpContext != null)
                {
                    var headerValue = _accessor.HttpContext.Request.Headers["telno"];
                    if (!string.IsNullOrEmpty(headerValue))
                    {
                        return Convert.ToInt64(headerValue);
                    }
                }
                return 0;
            }
        }

        public int? UYGULAMA_ID
        {
            get
            {
                if (_accessor.HttpContext != null)
                {
                    var headerValue = _accessor.HttpContext.Request.Headers["uygulama_id"];
                    if (!string.IsNullOrEmpty(headerValue))
                    {
                        return Convert.ToInt32(headerValue);
                    }
                }
                return null;
            }
        }

        public string ADISOYADI
        {
            get
            {
                IUsersDal kisiService = InstanceFactory.GetInstance<IUsersDal>();
                var kullanici = kisiService.GetAllQueryable(p=>p.EMAIL == MAIL).SingleOrDefault();
                if (kullanici != null)
                {
                    return kullanici.NAME + " " + kullanici.SURNAME;
                }
                return "";
            }
        }
        public string MAIL
        {
            get
            {
                if (_accessor.HttpContext != null)
                {
                    var headerValue = _accessor.HttpContext.Request.Headers["email"];
                    if (!string.IsNullOrEmpty(headerValue))
                    {
                        return headerValue.ToString();
                    }
                }
                return "";
            }
        }


        public string IP
        {
            get
            {
                if (_accessor.HttpContext != null)
                {
                    var headerValue = _accessor.HttpContext.Request.Headers["ip"];
                    if (!string.IsNullOrEmpty(headerValue))
                    {
                        return headerValue.ToString();
                    }
                }
                return string.Empty;
            }
        }

      
    }
}

using HerkesYazarOlsun.BLL.Accessor;
using HerkesYazarOlsun.DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Servis.Controllers
{
    public class BaseApiController : ControllerBase
    {
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IUserAccessor _userAccessor;
        public readonly IUnitOfWork _db;

        public long YETKILITCNO { get; private set; }
        public long TELNO { get; private set; }
        public string? MAIL { get; private set; }

        public BaseApiController(
            IUserAccessor userAccessor,
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor)
        {
            _userAccessor = userAccessor;
            _db = unitOfWork;
            _httpContextAccessor = httpContextAccessor;

            ReadHeaders();
        }

        private void ReadHeaders()
        {
            var context = _httpContextAccessor.HttpContext;
            if (context == null) return;

            var tckimlikno = context.Request.Headers["tckimlikno"].FirstOrDefault();
            if (!string.IsNullOrEmpty(tckimlikno) && long.TryParse(tckimlikno, out var tc))
            {
                YETKILITCNO = tc;
            }

            var email = context.Request.Headers["email"].FirstOrDefault();
            if (!string.IsNullOrEmpty(email))
            {
                MAIL = email;
            }

            var telno = context.Request.Headers["telno"].FirstOrDefault();
            if (!string.IsNullOrEmpty(telno) && long.TryParse(telno, out var tel))
            {
                TELNO = tel;
            }
        }
    }
}

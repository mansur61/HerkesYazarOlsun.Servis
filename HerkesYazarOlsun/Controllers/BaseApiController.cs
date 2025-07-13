
using HerkesYazarOlsun.BLL.Accessor;
using HerkesYazarOlsun.DataLayer;
using HerkesYazarOlsun.DataLayer.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace HerkesYazarOlsun.Servis.Controllers
{

    public class BaseApiController : ControllerBase
    {
        protected IHttpContextAccessor _httpContextAccessor;

        protected IUserAccessor _userAccessor;

        public readonly IUnitOfWork _db;

        private readonly DbContext _ctx;

        public long YETKILITCNO { get; set; }
        public long TELNO { get; set; }
        public string? MAIL { get; set; }

        public BaseApiController(IUserAccessor userAccessor, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _httpContextAccessor = userAccessor._accessor;
            _userAccessor = userAccessor;

            var dbType = configuration["DbType"];

            if (dbType == "Sql")
            {
                _ctx = new SqlServerContext(); // SQL Server DbContext
            }
            else
            {
                _ctx = new HerkesYazaOlsunContext(); // PostgreSQL DbContext
            }

            _db = unitOfWork;

            if (_httpContextAccessor.HttpContext.Request != null)
            {
                var values = _httpContextAccessor.HttpContext.Request.Headers["tckimlikno"];
               
                if (!string.IsNullOrEmpty(values))
                {
                    YETKILITCNO = Convert.ToInt64(values);
                }

                var values2 = _httpContextAccessor.HttpContext.Request.Headers["email"];

                if (!string.IsNullOrEmpty(values2))
                {
                    MAIL = values2;
                }

                var values3 = _httpContextAccessor.HttpContext.Request.Headers["telno"];

                if (!string.IsNullOrEmpty(values3))
                {
                    TELNO = Convert.ToInt64(values3);
                }

            }
        }
    }
}

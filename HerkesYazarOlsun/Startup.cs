// This Startup file is based on ASP.NET Core new project templates and is included
// as a starting point for DI registration and HTTP request processing pipeline configuration.
// This file will need updated according to the specific scenario of the application being upgraded.
// For more information on ASP.NET Core startup files, see https://docs.microsoft.com/aspnet/core/fundamentals/startup

using HerkesYazarOlsun.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Rotativa.AspNetCore;
using HerkesYazarOlsun.BLL.Ioc;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.DataLayer.Context;

namespace HerkesYazarOlsun.Servis
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            SetAppSettingsVariable();
           
            services.AddDbContext<HerkesyazarolsunContext>();
            services.AddHttpContextAccessor();

          //  services.AddSingleton<IUserAccessor, HttpUserAccessor>();
           // services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddControllersWithViews();
            services.AddMvcCore();
            services.AddMvc();

            services.IoCDataAccessLayerRegister();
            services.IoCBusinessLogicLayerRegister();

            InstanceFactory.Provider = services.BuildServiceProvider();


            //services.AddControllersWithViews(ConfigureMvcOptions).
            //    // Newtonsoft.Json is added for compatibility reasons
            //    // The recommended approach is to use System.Text.Json for serialization
            //    // Visit the following link for more guidance about moving away from Newtonsoft.Json to System.Text.Json
            //    // https://docs.microsoft.com/dotnet/standard/serialization/system-text-json-migrate-from-newtonsoft-how-to
            //    .AddNewtonsoftJson(options =>
            //    {
            //        options.UseMemberCasing();
            //    });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
			app.Use((context, next) =>
			{
				if (context.Request.Path.Value.StartsWith("//"))
				{
					context.Request.Path = new PathString(context.Request.Path.Value.Replace("//", "/"));
				}
				return next();
			});

			app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            env.WebRootPath = "";
            RotativaConfiguration.Setup((Microsoft.AspNetCore.Hosting.IHostingEnvironment)env);
        }

        private void ConfigureMvcOptions(MvcOptions mvcOptions)
        {
        }

        private void SetAppSettingsVariable()
        {
            DbSettings.HerkesYazarOlsunDbContext  = Configuration.GetConnectionString("HerkesYazarOlsunDb2");
           
        }
    }
}

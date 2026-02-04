using CoreApplication2.Data;
using CoreApplication2.Data.Interfaces;
using CoreApplication2.Data.Mocks;
using CoreApplication2.Data.Models;
using CoreApplication2.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CoreApplication2
{
    public class Startup
    {
        private ILoggerFactory _loggerFactory;
        private IConfigurationRoot _configurationRoot;

        public Startup(ILoggerFactory loggerFactory, IWebHostEnvironment hostingEnvironment)
        {
            _loggerFactory = loggerFactory;
            _configurationRoot = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();

        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnectionString")));
            services.AddTransient<ICarRepository, CarRespository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShoppingCart.GetCart(sp));

            services.AddMvc(options => 
                         options.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();

        }

        private Func<IServiceProvider, object> MockCarRepository()
        {
            throw new NotImplementedException();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            
        }
    }

}

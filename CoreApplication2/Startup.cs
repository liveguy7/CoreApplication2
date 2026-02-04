using CoreApplication2.Data.Interfaces;
using CoreApplication2.Data.Mocks;

namespace CoreApplication2
{
    public class Startup
    {
        private ILoggerFactory _loggerFactory;

        public Startup(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICarRepository, MockCarRepository>();
            services.AddTransient<ICategoryRepository, MockCategoryRepository>();
            services.AddMvc(options => 
                         options.EnableEndpointRouting = false);

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

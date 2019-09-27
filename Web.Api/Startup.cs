
namespace Generic
{
    using Generic.Storage.Interfaces;
    using Generic.Storage.Repository;
    using Autofac;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Serilog;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IContainer ApplicationContainer { get; private set; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Log.Logger.Information("In ConfigureServices");

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            var builder = new ContainerBuilder();

            var connectionString = Configuration["AppSettings:SqlConnectionString"];
            var unitOfWork = new UnitOfWork(Log.Logger, connectionString);

            services.AddTransient(typeof(IUnitOfWork), (s) => {
                return unitOfWork;
            });

            ApplicationContainer = builder.Build();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

using System.IO;
using CameraServer.Models.Devices;
using CameraServer.Models.HardwareTrasmittableData;
using CameraServer.Models.Sensors;
using CameraServer.Models.Users;
using CameraServer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CameraServer
{
    using Models;

    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            var dbPrefix = Configuration["Production:SqliteConnStringPrefix"];
            var dbName = Configuration["Production:SqliteDbName"];
            var dbLocationDir = Directory.GetCurrentDirectory();
            var connection = dbPrefix + Path.Combine(dbLocationDir, dbName);

            services.AddEntityFrameworkSqlite()
                .AddDbContext<MainContext>(options => options.UseSqlite(connection))
                .AddDbContext<UserContext>(options => options.UseSqlite(connection));

            services.AddMvc();

            services.AddScoped<IRepository<DeviceAction>, DeviceActionsRepository>();
            services.AddScoped<IRepository<TriggerDeviceAction>, TriggerDeviceActionRepository>();
            services.AddScoped<IRepository<BaseSensor>, BaseSensorRepository>();
            services.AddScoped<IRepository<CameraPhoto>, CameraPhotosRepository>();
            services.AddScoped<IRepository<PhotoTransmit>, PhotoTransmitsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = "Cookies",
                LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login"),
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Main}/{action=Index}/{id?}");
            });
        }
    }
}

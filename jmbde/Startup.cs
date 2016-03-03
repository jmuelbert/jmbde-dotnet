using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Localization;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Data.Entity;

using jmbde.Models;

namespace jmbde
{
    
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
            
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            // services.AddLocalization(options => options.ResourcePath = "Resources");
            
            // Add framework services.
            // *********************************
            // SQlite Database
            // *********************************
            // Add EF services to the services container.
            services.AddEntityFramework()
                  .AddSqlite()
                  .AddDbContext<JMBDEContext>(options =>
                     options.UseSqlite(Configuration["Data:SQLiteConnectionString" ]=
                      $@"Data Source=jmbde.db"));
   
            // Add framework services.
            // *********************************
            // MS Sql Database
            // *********************************
            //services.AddEntityFramework()
            //    .AddSqlServer()
            //    .AddDbContext<JMBDEContext>(options => 
            //        options.UseSqlServer(Configuration["Data:MSSQLConnectionString"]));
             
            // Add framework services.
            // Add MVC services to the services container.
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddMvc()
                .AddViewLocalization(options => options.ResourcesPath = "Resources")
                .AddDataAnnotationsLocalization();
                
            // Add other services
            
        }
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                        IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // Configure the HTTP request pipeline.
            // Add the console logger.
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Add Error handling middleware which catches all application specific errors and
                // send the request to the following path or controller action.
                app.UseExceptionHandler("/Home/Error");
               
                // For more details on creating database during deployment see
                // http://go.microsoft.con&fwlink/?LinkID=615859
                try
                {
                    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                    {
                        serviceScope.ServiceProvider.GetService<JMBDEContext>()
                            .Database.Migrate();    
                    }
                }
                catch (System.Exception exp)
                {
                    Console.WriteLine("Exception: {1}", exp); 
                }
            }
            

            app.UseIISPlatformHandler();

            // Add static files to request pipeline.
            app.UseStaticFiles();

            var requestLocalizationOptions = new RequestLocalizationOptions
            {
                // Set options here to change middleware behavior
                SupportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("de-DE"),
                    new CultureInfo("es-ES")
                },
                SupportedUICultures = new List<CultureInfo>
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("de-DE"),
                    new CultureInfo("es-ES")

                },
                RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new CookieRequestCultureProvider
                    {
                        CookieName = "_cultureLocalizationStackOverflow"
                    },
                    new AcceptLanguageHeaderRequestCultureProvider
                    {

                    }
                    
                }
            };

            app.UseRequestLocalization(requestLocalizationOptions, defaultRequestCulture: new RequestCulture("en-US"));  
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Employee}/{action=Index}/{id?}");
                   
            });
        }

        // Entry point for the application.
        public static void Main(string[] args) => Microsoft.AspNet.Hosting.WebApplication.Run<Startup>(args);
    }
}

/**************************************************************************
 **
 ** SPDX-FileCopyrightText: © 2016-2023 Jürgen Mülbert
 **
 ** SPDX-License-Identifier: EUPL-1.2
 **
 *************************************************************************/

using System;
using System.Globalization;
using System.IO;

using JMuelbert.BDE.Shared.Data;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace JMuelbert.BDE
{
    /// <summary>
    /// Startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// The _env.
        /// </summary>
        private readonly IWebHostEnvironment _env;
        /// <summary>
        /// The logger.
        /// </summary>

        /// <summary>
        /// Initializes a new instance of the <see cref="T:JMBde.Startup"/> class.
        /// </summary>
        /// <param name="env"></param>
        /// <param name="logger">Logger.</param>
        /// <param name="configuration">Configuration.</param>
        public Startup(IWebHostEnvironment env, IConfiguration configuration, ILogger<Startup> logger)
        {
            _env = env;
            Configuration = configuration;
            _logger = logger;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the services.
        /// This method gets called by the runtime.
        /// Use this method to add services to the container
        /// </summary>
        /// <param name="services">Services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Set the path to the sqlite database
            var appDataPath = "";
            var dbString = "";
            // Get the settings from appsettings.json
            var dbPath = Configuration.GetSection("Data").GetSection("DBPath").Value;
            var dbName = Configuration.GetSection("Data").GetSection("DBName").Value;
            appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            dbString = Path.Combine(appDataPath, dbPath);
            dbPath = Path.Combine(dbString, dbName);

            DirectoryInfo di = new DirectoryInfo(dbString);
            try
            {
                if (di.Exists)
                {
                    _logger.LogInformation($"The Directory {dbString} exists", dbString);
                }
                else
                {
                    // Try Create the Directory
                    di.Create();
                    _logger.LogInformation($"The Directory {dbString} created", dbString);
                }
            }
            catch (Exception e)
            {
                _logger.LogInformation($"The Directory could not created {e}", e);
                throw;
            }

            // Build the connenction string.
            var connection = "Data Source=" + dbPath;
            _logger.LogInformation($"The Data Source {connection} ", connection);

            if (_env.IsDevelopment())
            {
                // Development service configuration

                _logger.LogInformation("Development environment");

            }
            else
            {
                // Non-development service configuration

                _logger.LogInformation($"Environment: {_env.EnvironmentName}");
            }

            // Add framework services.
            services.AddDbContext<BDEContext>(options => options.UseSqlite(connection));

            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<BDEContext>();
            services.AddRazorPages();
        }

        /// <summary>
        /// Configure the specified app and env.
        /// This method gets called by the runtime. Use this method to configure the
        /// HTTP request pipeline.
        /// </summary>
        /// <param name="app">App.</param>
        /// <param name="env">Env.</param>
        [Obsolete]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                _logger.LogInformation("In Development environment");
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();

                #region Localization_MVC_Service
                // For more details on creating database during deployment,
                // see: http://go.microsoft.com/fwlink/?LinkID=615859
                try
                {
                    using (var serviceScope =
                               app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                                   .CreateScope())
                    {
                        serviceScope.ServiceProvider.GetService<BDEContext>().Database.Migrate();
                    }
                }
                catch
                {
                }

                var supportedCultures = new[] { new CultureInfo("en-US"), new CultureInfo("de") };

                app.UseRequestLocalization(
                    new RequestLocalizationOptions
                    {
                        DefaultRequestCulture = new RequestCulture("en-US"),
                        // Formatting numbers, dates, etc.
                        SupportedCultures = supportedCultures,
                        // UI strings that we have localized.
                        SupportedUICultures = supportedCultures
                    });
                #endregion
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseRequestLocalization();

            app.UseCookiePolicy();

            app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
        }
    }
}
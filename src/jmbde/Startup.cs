/**************************************************************************
 **
 ** Copyright (c) 2016-2019 Jürgen Mülbert. All rights reserved.
 **
 ** This file is part of jmbde
 **
 ** Licensed under the EUPL, Version 1.2 or – as soon they
 ** will be approved by the European Commission - subsequent
 ** versions of the EUPL (the "Licence");
 ** You may not use this work except in compliance with the
 ** Licence.
 ** You may obtain a copy of the Licence at:
 **
 ** https://joinup.ec.europa.eu/page/eupl-text-11-12
 **
 ** Unless required by applicable law or agreed to in
 ** writing, software distributed under the Licence is
 ** distributed on an "AS IS" basis,
 ** WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 ** express or implied.
 ** See the Licence for the specific language governing
 ** permissions and limitations under the Licence.
 **
 ** Lizenziert unter der EUPL, Version 1.2 oder - sobald
 **  diese von der Europäischen Kommission genehmigt wurden -
 ** Folgeversionen der EUPL ("Lizenz");
 ** Sie dürfen dieses Werk ausschließlich gemäß
 ** dieser Lizenz nutzen.
 ** Eine Kopie der Lizenz finden Sie hier:
 **
 ** https://joinup.ec.europa.eu/page/eupl-text-11-12
 **
 ** Sofern nicht durch anwendbare Rechtsvorschriften
 ** gefordert oder in schriftlicher Form vereinbart, wird
 ** die unter der Lizenz verbreitete Software "so wie sie
 ** ist", OHNE JEGLICHE GEWÄHRLEISTUNG ODER BEDINGUNGEN -
 ** ausdrücklich oder stillschweigend - verbreitet.
 ** Die sprachspezifischen Genehmigungen und Beschränkungen
 ** unter der Lizenz sind dem Lizenztext zu entnehmen.
 **
 **************************************************************************/

using System;
using System.Globalization;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using JMuelbert.BDE.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Microsoft.AspNetCore.Localization;

namespace JMuelbert.BDE
{
    /// <summary>
    /// Startup.
    /// </summary>
    public class Startup {
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
        /// <param name="logger">Logger.</param>
        /// <param name="configuration">Configuration.</param>
        public Startup (IWebHostEnvironment env, IConfiguration configuration,
            ILogger<Startup> logger) {
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
        // This method gets called by the runtime.
        // Use this method to add services to the container
        /// </summary>
        /// <param name="services">Services.</param>
        public void ConfigureServices (IServiceCollection services) {
            // Set the path to the sqlite database
            var appDataPath = "";
            var dbString = "";
            // Get the settings from appsettings.json
            var dbPath = Configuration.GetSection ("Data").GetSection ("DBPath").Value;
            var dbName = Configuration.GetSection ("Data").GetSection ("DBName").Value;
            appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            dbString = Path.Combine (appDataPath, dbPath);
            dbPath = Path.Combine (dbString,
                                     dbName);

            DirectoryInfo di = new DirectoryInfo (dbString);
            try {
                if (di.Exists) {
                    _logger.LogInformation ($"The Directory { dbString } exists", dbString);
                } else {

                    // Try Create the Directory
                    di.Create ();
                    _logger.LogInformation ($"The Directory { dbString } created", dbString);
                }
            } catch (Exception e) {
                _logger.LogInformation ($"The Directory could not created {e}", e);
                throw;
            }

            // Build the connenction string.
            var connection = "Data Source=" + dbPath;
            _logger.LogInformation ($"The Data Source { connection } ", connection);

            if (_env.IsDevelopment ()) {
                // Development service configuration

                _logger.LogInformation ("Development environment");

            } else {
                // Non-development service configuration

                _logger.LogInformation ($"Environment: {_env.EnvironmentName}");
            }

            // Add framework services.
            services.AddDbContext<ApplicationDbContext> (options =>
                options.UseSqlite (connection));

            services.AddDefaultIdentity<IdentityUser> ()
                    .AddEntityFrameworkStores<ApplicationDbContext> ();
            services.AddRazorPages();
        }

        /// <summary>
        /// Configure the specified app and env.
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">App.</param>
        /// <param name="env">Env.</param>
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {

            if (env.IsDevelopment ()) {
                _logger.LogInformation ("In Development environment");
                app.UseDeveloperExceptionPage ();
                app.UseDatabaseErrorPage ();
            }
            else
            {
                app.UseExceptionHandler ("/Error");
                app.UseHsts ();

                #region Localization_MVC_Service
                // For more details on creating database during deployment,
                // see: http://go.microsoft.com/fwlink/?LinkID=615859
                try {
                    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory> ()
                        .CreateScope ()) {
                        serviceScope.ServiceProvider.GetService<ApplicationDbContext> ()
                            .Database.Migrate ();
                    }
                } catch { }

                var supportedCultures = new [] {
                    new CultureInfo ("en-US"),
                    new CultureInfo ("de")
                };

                app.UseRequestLocalization (new RequestLocalizationOptions {
                    DefaultRequestCulture = new RequestCulture ("en-US"),
                        // Formatting numbers, dates, etc.
                        SupportedCultures = supportedCultures,
                        // UI strings that we have localized.
                        SupportedUICultures = supportedCultures
                });
                #endregion
            }

            app.UseHttpsRedirection ();
            app.UseStaticFiles ();

            app.UseRouting();

            app.UseRequestLocalization ();

            app.UseCookiePolicy ();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}

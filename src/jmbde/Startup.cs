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
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JMuelbert.BDE.Data;
using JMuelbert.BDE.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace JMuelbert.BDE {
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
        private readonly IHostingEnvironment _env;
        /// <summary>
        /// The logger.
        /// </summary>

        /// <summary>
        /// Initializes a new instance of the <see cref="T:JMBde.Startup"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="configuration">Configuration.</param>
        public Startup (IHostingEnvironment env, IConfiguration configuration,
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
            var homePath = "";
            var dbString = "";
            // Get the settings from appsettings.json
            var dbPath = Configuration.GetSection ("Data").GetSection ("DBPath").Value;
            var dbName = Configuration.GetSection ("Data").GetSection ("DBName").Value;
            // Get the OS
            // WINDIR is only available in Windows
            var os = Environment.GetEnvironmentVariable ("WINDIR");

            // Check if the os variable is set then the OS is Windows
            if (os != null) {
                homePath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.ApplicationData);
                appDataPath = Path.Combine (homePath, dbPath);
                dbString = Path.Combine (appDataPath, dbName);
            } else {
                // This is available by macOS
                os = Environment.GetEnvironmentVariable ("_system_type");

                // Darwin is macOS
                if (os.Equals ("Darwin")) {
                    homePath = Environment.GetEnvironmentVariable ("HOME");
                    appDataPath = Path.Combine (homePath, "Library/Application Support");
                    appDataPath = Path.Combine (appDataPath, dbPath);
                    dbString = Path.Combine (appDataPath, dbName);
                } else {
                    // This is for Linux
                    homePath = Environment.GetEnvironmentVariable ("HOME");
                    appDataPath = Path.Combine (homePath, "local");
                    appDataPath = Path.Combine (homePath, dbPath);
                    dbString = Path.Combine (appDataPath, dbName);
                }
            }

            DirectoryInfo di = new DirectoryInfo (appDataPath);
            try {
                if (di.Exists) {
                    _logger.LogInformation ($"The Directory { appDataPath} exists", appDataPath);
                } else {

                    // Try Create the Directory
                    di.Create ();
                    _logger.LogInformation ($"The Directory { appDataPath} created", appDataPath);
                }
            } catch (Exception e) {
                _logger.LogInformation ($"The Directory could not created {e}", e);
                throw;
            }

            // Build the connenction string.
            var connection = "Data Source=" + dbString;

            if (_env.IsDevelopment ()) {
                // Development service configuration

                _logger.LogInformation ("Development environment");

            } else {
                // Non-development service configuration

                _logger.LogInformation ($"Environment: {_env.EnvironmentName}");
            }

            services.Configure<CookiePolicyOptions> (options => {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Add framework services.
            services.AddDbContext<ApplicationDbContext> (options =>
                options.UseSqlite (connection));

            services.AddDefaultIdentity<IdentityUser> ()
                .AddDefaultUI (UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext> ();

            #region Localization_Resources
            services.AddLocalization (options => options.ResourcesPath = "Resources");
            #endregion

            services.AddMvc (options => {
                    options.Filters.Add (new AsyncPageFilter (_logger));
                })
                .AddViewLocalization (LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization ()
                .SetCompatibilityVersion (CompatibilityVersion.Version_2_2);

            #region Localization_Options
            services.Configure<RequestLocalizationOptions> (options => {
                var supportedCultures = new List<CultureInfo> {
                new CultureInfo ("en-US"),
                new CultureInfo ("de")
                };

                options.DefaultRequestCulture = new RequestCulture ("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            #endregion
        }

        /// <summary>
        /// Configure the specified app and env.
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">App.</param>
        /// <param name="env">Env.</param>
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {

            if (env.IsDevelopment ()) {
                _logger.LogInformation ("In Development environment");
                app.UseDeveloperExceptionPage ();
                app.UseDatabaseErrorPage ();
            }

            if (env.IsProduction () || env.IsStaging ()) {
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
            app.UseRequestLocalization ();
            app.UseCookiePolicy ();

            app.UseMvc ();
        }
    }
}

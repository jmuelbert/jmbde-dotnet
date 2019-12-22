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
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using JMuelbert.BDE.Data;

namespace JMuelbert.BDE {
    /// <summary>
    /// Program.
    /// </summary>
    public class Program {

        public static readonly Dictionary<string, string> switchMappings =
            new Dictionary<string, string> { { "-Help", "Help" }
            };

        public static readonly Dictionary<string, string> arrayDict =
            new Dictionary<string, string> { { "-Help", "Help" }
            };

        public static IWebHostEnvironment HostingEnvironment { get; set; }
        public static IConfiguration Configuration { get; set; }

        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        /// <summary>
        public static void Main (string[] args) {

         var host = CreateWebHostBuilder(args).Build();

        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<ApplicationDbContext>();
                // SeedData.Initialize(services, "not used");
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred seeding the DB.");
            }
        }

        host.Run();
        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }

    //     public static IWebHostBuilder CreateWebHostBuilder (string[] args) =>
    //         WebHost.CreateDefaultBuilder (args)
    //         .ConfigureAppConfiguration ((hostingContext, config) => {
    //             config.SetBasePath (Directory.GetCurrentDirectory ());
    //             config.AddInMemoryCollection (arrayDict);
    //             config.AddIniFile ("config.ini", optional : true, reloadOnChange : true);
    //             config.AddJsonFile ("json_array.json", optional : true, reloadOnChange : false);
    //             config.AddJsonFile ("config.json", optional : true, reloadOnChange : false);
    //             config.AddXmlFile ("config.xml", optional : true, reloadOnChange : false);

    //             // Call other providers here and call AddCommandLine last.
    //             config.AddCommandLine (args, switchMappings);

    //             HostingEnvironment = hostingContext.HostingEnvironment;
    //             Configuration = config.Build ();
    //         })
    //         .Configure (app => {
    //             var loggerFactory = app.ApplicationServices
    //                 .GetRequiredService<ILoggerFactory> ();
    //             var logger = loggerFactory.CreateLogger<Program> ();

    //             logger.LogInformation ("Logged in Configure");
    //         })
    //         .ConfigureLogging ((hostingContext, logging) => {
    //             logging.AddConfiguration (hostingContext.Configuration.GetSection ("Logging"));
    //             logging.AddConsole ();
    //             logging.AddDebug ();
    //             logging.AddEventSourceLogger ();
    //         })
    //         .UseStartup<Startup> ();
    // }
}

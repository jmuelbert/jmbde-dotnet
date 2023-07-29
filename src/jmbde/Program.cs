/**************************************************************************
 **
 ** SPDX-FileCopyrightText: 2016-2023 Jürgen Mülbert
 ** Copyright (c) 2016-2023 Jürgen Mülbert. All rights reserved.
 ** SPDX-License-Identifier: EUPL-1.2
 **
 **************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JMuelbert.BDE.Shared.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace JMuelbert.BDE
{
	/// <summary>
	/// Program.
	/// </summary>
	public class Program
	{

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
		public static void Main(string[] args)
		{

			var host = CreateWebHostBuilder(args).Build();

			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;

				try
				{
					var bdeContext = services.GetRequiredService<BDEContext>();
					DataInitializer.Initialize(bdeContext);
				}
				catch (System.Exception ex)
				{
					var logger = services.GetRequiredService<ILogger<Program>>();
					logger.LogError(ex, "An error occurred creating the DB.");
				}
			}
			host.Run();
		}

		private static void CreateDbIfNotExists(IWebHost host)
		{
			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;

				try
				{
					var context = services.GetRequiredService<BDEContext>();
					context.Database.EnsureCreated();
				}
				catch (Exception ex)
				{
					var logger = services.GetRequiredService<ILogger<Program>>();
					logger.LogError(ex, "An error occurred creating the DB.");
				}
			}
		}
		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
			.ConfigureAppConfiguration((hostingContext, config) =>
			{
				config.SetBasePath(Directory.GetCurrentDirectory());
				// config.AddInMemoryCollection (arrayDict);
				config.AddIniFile("config.ini", optional: true, reloadOnChange: true);
				config.AddJsonFile("json_array.json", optional: true, reloadOnChange: false);
				config.AddJsonFile("config.json", optional: true, reloadOnChange: false);
				config.AddXmlFile("config.xml", optional: true, reloadOnChange: false);

				// Call other providers here and call AddCommandLine last.
				config.AddCommandLine(args, switchMappings);

				HostingEnvironment = hostingContext.HostingEnvironment;
				Configuration = config.Build();
			})
			.Configure(app =>
			{
				var loggerFactory = app.ApplicationServices
					.GetRequiredService<ILoggerFactory>();
				var logger = loggerFactory.CreateLogger<Program>();

				logger.LogInformation("Logged in Configure");
			})
			.ConfigureLogging((hostingContext, logging) =>
			{
				logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
				logging.AddConsole();
				logging.AddDebug();
				logging.AddEventSourceLogger();
			})
			.UseStartup<Startup>();
	}
}

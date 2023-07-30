
/**************************************************************************
 **
 ** SPDX-FileCopyrightText: © 2016-2023 Jürgen Mülbert
 **
 ** SPDX-License-Identifier: EUPL-1.2
 **
 *************************************************************************/

using System;

namespace JMuelbert.BDE.Pages
{
	using Microsoft.AspNetCore.Mvc.RazorPages;
	using Microsoft.Extensions.Logging;

	/// <summary>
	/// About model.
	/// </summary>
	public class AboutModel : PageModel
	{
		/// <summary>
		/// The logger.
		/// </summary>
		private readonly ILogger _logger;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:JMBde.Pages.AboutModel"/> class.
		/// </summary>
		/// <param name="logger">Logger.</param>
		public AboutModel(ILogger<AboutModel> logger)
		{
			_logger = logger;
		}

		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value>The message.</value>
		public string Message { get; set; }

		/// <summary>
		/// Ons the get.
		/// </summary>
		public void OnGet()
		{
			Message = $"About page visited at {DateTime.UtcNow.ToLongTimeString()}";
			_logger.LogDebug("About/OnGet");
		}

		/// <summary>
		/// Ons the post.
		/// </summary>
		public void OnPost()
		{
			_logger.LogDebug("About/OnPost");
		}
	}
}

/**************************************************************************
 **
 ** SPDX-FileCopyrightText: © 2016-2023 Jürgen Mülbert
 **
 ** SPDX-License-Identifier: EUPL-1.2
 **
 *************************************************************************/

using System;
using System.Threading.Tasks;
using JMuelbert.BDE.Shared.Data;
using JMuelbert.BDE.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace JMuelbert.BDE.Pages.Manufacturers
{
	/// <summary>
	/// Create model.
	/// </summary>
	public class CreateModel : PageModel
	{
		/// <summary>
		/// The context.
		/// </summary>
		private readonly BDEContext _context;

		/// <summary>
		/// The logger.
		/// </summary>
		private readonly ILogger _logger;

		/// <summary>
		/// Initializes a new instance of the <see
		/// cref="T:JMuelbert.BDE.Pages.Manufacturers.IndexModel"/> class.
		/// </summary>
		/// <param name="logger">Logger.</param>
		/// <param name="context">Context.</param>

		public CreateModel(ILogger<CreateModel> logger, BDEContext context)
		{
			_logger = logger;
			_context = context;
		}

		/// <summary>
		/// Ons the get.
		/// </summary>
		/// <returns>The get.</returns>
		public IActionResult OnGet()
		{
			_logger.LogDebug("Manufacturers/Create/OnGet");
			return Page();
		}

		/// <summary>
		/// Gets or sets the Manufacturer.
		/// </summary>
		/// <value>The Manufacturer.</value>
		[BindProperty]
		public Manufacturer Manufacturer { get; set; }

		/// <summary>
		/// Ons the get async.
		/// </summary>
		/// <returns>The get async.</returns>
		public async Task<IActionResult> OnPostAsync()
		{
			_logger.LogDebug("Manufacturers/Create/OnPostAsync");
			if (!ModelState.IsValid)
			{
				return Page();
			}

			var emptyManufacturer = new Manufacturer();

			if (await TryUpdateModelAsync<Manufacturer>(
					emptyManufacturer,
					"manufacturer",  // Prefix for form value
					m => m.Name, m => m.Name2, m => m.Supporter, m => m.Street, m => m.Street22,
					m => m.MailAddress, m => m.PhoneNumber, m => m.FaxNumber, m => m.HotlineNumber,
					m => m.LastUpdate)
					.ConfigureAwait(false))
			{
				_context.Manufacturer.Add(emptyManufacturer);
				await _context.SaveChangesAsync().ConfigureAwait(false);

				return RedirectToPage("./Index");
			}
			return null;
		}
	}
}
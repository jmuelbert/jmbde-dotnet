/**************************************************************************
 **
 ** SPDX-FileCopyrightText: 2016-2023 Jürgen Mülbert
 ** Copyright (c) 2016-2023 Jürgen Mülbert. All rights reserved.
 ** SPDX-License-Identifier: EUPL-1.2
 **
 **************************************************************************/

using System;
using System.Threading.Tasks;
using JMuelbert.BDE.Shared.Data;
using JMuelbert.BDE.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace JMuelbert.BDE.Pages.Phones
{ /// <summary>
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
		/// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Phones.IndexModel"/> class.
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
			_logger.LogDebug("Phones/Create/OnGet");
			return Page();
		}

		/// <summary>
		/// Gets or sets the Phone.
		/// </summary>
		/// <value>The Phone.</value>

		[BindProperty]
		public Phone Phone { get; set; }

		/// <summary>
		/// Ons the get async.
		/// </summary>
		/// <returns>The get async.</returns>
		public async Task<IActionResult> OnPostAsync()
		{
			_logger.LogDebug("Phones/Create/OnPostAsync");

			if (!ModelState.IsValid)
			{
				return Page();
			}

			var emptyPhone = new Phone();

			if (await TryUpdateModelAsync<Phone>(
					emptyPhone,
					"phone", // Preset for form value
					p => p.Number,
					p => p.SerialNumber,
					p => p.Pin,
					p => p.Active,
					p => p.Replace,
					p => p.LastUpdate
				).ConfigureAwait(false))
			{
				_context.Phone.Add(emptyPhone);
				await _context.SaveChangesAsync().ConfigureAwait(false);

				return RedirectToPage("./Index");
			}
			return null;
		}
	}
}

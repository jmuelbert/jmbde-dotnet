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

namespace JMuelbert.BDE.Pages.Inventories
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
		/// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Inventories.IndexModel"/>
		/// class.
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
			return Page();
		}

		[BindProperty]
		public Inventory Inventory { get; set; }

		public async Task<IActionResult> OnPostAsync()
		{
			_logger.LogDebug("Inventories/Create/OnGet");

			if (!ModelState.IsValid)
			{
				return Page();
			}

			var emptyInventory = new Inventory();

			if (await TryUpdateModelAsync<Inventory>(emptyInventory,
													 "inventory",  // Prefix for form value
													 i => i.Identifier, i => i.Description, i => i.Active,
													 i => i.LastUpdate)
					.ConfigureAwait(false))
			{
				_context.Inventory.Add(emptyInventory);
				await _context.SaveChangesAsync().ConfigureAwait(false);

				return RedirectToPage("./Index");
			}
			return null;
		}
	}
}
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

namespace JMuelbert.BDE.Pages.ChipCards
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
		/// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.ChipCard.CreateModel"/>
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
			_logger.LogDebug("ChipCard/Create/OnGet");
			return Page();
		}
		/// <summary>
		/// Gets or sets the chip card.
		/// </summary>
		/// <value>The chip card door.</value>
		[BindProperty]
		public ChipCard ChipCard { get; set; }

		/// <summary>
		/// Ons the post async.
		/// </summary>
		/// <returns>The post async.</returns>
		public async Task<IActionResult> OnPostAsync()
		{
			_logger.LogDebug($"ChipCard/Create/OnPostAsync");
			if (!ModelState.IsValid)
			{
				return Page();
			}

			var emptyChipCard = new ChipCard();

			if (await TryUpdateModelAsync<ChipCard>(emptyChipCard,
													"chipcard",  // Prefix for form value.
													c => c.Number, c => c.Locked, c => c.LastUpdate)
					.ConfigureAwait(false))
			{
				_context.ChipCard.Add(emptyChipCard);
				await _context.SaveChangesAsync().ConfigureAwait(false);

				return RedirectToPage("./Index");
			}
			return null;
		}
	}
}
/**************************************************************************
 **
 ** SPDX-FileCopyrightText:  © 2016-2023 Jürgen Mülbert
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

namespace JMuelbert.BDE.Pages.ChipCards
{
	/// <summary>
	/// Edit model.
	/// </summary>
	public class EditModel : PageModel
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
		/// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.ChipCards.EditModel"/>
		/// class.
		/// </summary>
		/// <param name="logger"></param>
		/// <param name="context">Context.</param>
		public EditModel(ILogger<EditModel> logger, BDEContext context)
		{
			_logger = logger;
			_context = context;
		}

		/// <summary>
		/// Gets or sets the chip card door.
		/// </summary>
		/// <value>The chip card door.</value>
		[BindProperty]
		public ChipCard ChipCard { get; set; }

		/// <summary>
		/// Ons the get async.
		/// </summary>
		/// <returns>The get async.</returns>
		/// <param name="id">Identifier.</param>
		public async Task<IActionResult> OnGetAsync(int? id)
		{
			_logger.LogDebug($"ChipCards/Edit/OnGetAsync ({id}");

			if (id == null)
			{
				return NotFound();
			}

			ChipCard = await _context.ChipCard.FindAsync(id).ConfigureAwait(false);

			if (ChipCard == null)
			{
				return NotFound();
			}
			return Page();
		}

		/// <summary>
		/// OnPostAsync
		/// </summary>
		/// <param name="id "></param>
		/// <returns></returns>
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			_logger.LogDebug($"ChipCards/Edit/OnPostAsync {id})");

			if (!ModelState.IsValid)
			{
				return Page();
			}

			var chipcardToUpdate = await _context.ChipCard.FindAsync(id).ConfigureAwait(false);

			if (await TryUpdateModelAsync<ChipCard>(chipcardToUpdate,
													"chipcard ",  // Prefix for form value.
													c => c.Number, c => c.Locked, c => c.LastUpdate)
					.ConfigureAwait(false))
			{
				await _context.SaveChangesAsync().ConfigureAwait(false);
				return RedirectToPage(". / Index ");
			}
			return Page();
		}
	}
}
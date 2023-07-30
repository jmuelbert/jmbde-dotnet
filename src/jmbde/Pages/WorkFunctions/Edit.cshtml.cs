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

namespace JMuelbert.BDE.Pages.WorkFunctions
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
		/// Initializes a new instance of the <see
		/// cref="T:JMuelbert.BDE.Pages.WorkFunctions.EditModel"/> class.
		/// </summary>
		/// <param name="logger">Logger.</param>
		/// <param name="context">Context.</param>

		public EditModel(ILogger<EditModel> logger, BDEContext context)
		{
			_logger = logger;
			_context = context;
		}

		/// <summary>
		/// Gets or sets the Function.
		/// </summary>
		/// <value>The Function.</value>
		[BindProperty]
		public WorkFunction WorkFunction { get; set; }

		/// <summary>
		/// Ons the get async.
		/// </summary>
		/// <returns>The get async.</returns>
		/// <param name="id">Identifier.</param>
		public async Task<IActionResult> OnGetAsync(int? id)
		{
			_logger.LogDebug($"Functions/Edit/OnGetAsync({id})");

			if (id == null)
			{
				return NotFound();
			}

			WorkFunction = await _context.WorkFunction.FindAsync(id).ConfigureAwait(false);

			if (WorkFunction == null)
			{
				return NotFound();
			}
			return Page();
		}
		/// <summary>
		/// OnPostAsync
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			_logger.LogDebug($"Functions/Edit/OnPostAsync({id})");

			if (!ModelState.IsValid)
			{
				return Page();
			}

			var functionToUpdate = await _context.WorkFunction.FindAsync(id).ConfigureAwait(false);

			if (await TryUpdateModelAsync<WorkFunction>(functionToUpdate,
														"function",  // Prefix for form value
														f => f.Name, f => f.Priority, f => f.LastUpdate)
					.ConfigureAwait(false))
			{
				await _context.SaveChangesAsync().ConfigureAwait(false);
				return RedirectToPage("./Index");
			}

			return Page();
		}
	}
}

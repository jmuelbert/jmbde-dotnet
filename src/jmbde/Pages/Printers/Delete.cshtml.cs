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

namespace JMuelbert.BDE.Pages.Printers
{
	/// <summary>
	/// Delete model.
	/// </summary>
	public class DeleteModel : PageModel
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
		/// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Printers.IndexModel"/> class.
		/// </summary>
		/// <param name="logger">Logger.</param>
		/// <param name="context">Context.</param>

		public DeleteModel(ILogger<DeleteModel> logger, BDEContext context)
		{
			_logger = logger;
			_context = context;
		}

		/// <summary>
		/// Gets or sets the Printer.
		/// </summary>
		/// <value>The Printer.</value>
		[BindProperty]
		public Printer Printer { get; set; }

		/// <summary>
		/// Gets or sets the ErrorMessage.
		/// </summary>
		/// <value>The ErrorMessage.</value>
		public string ErrorMessage { get; set; }

		/// <summary>
		/// Ons the get async.
		/// </summary>
		/// <returns>The get async.</returns>
		/// <param name="id">Identifier.</param>
		/// <param name="saveChangesError">Save changes error.</param>
		public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
		{
			_logger.LogDebug($"Printers/Delete/OnGetAsync({id}, {saveChangesError})");

			if (id == null)
			{
				return NotFound();
			}

			Printer = await _context.Printer
				.AsNoTracking()
				.FirstOrDefaultAsync(p => p.ID == id)
				.ConfigureAwait(false);

			if (Printer == null)
			{
				return NotFound();
			}

			if (saveChangesError.GetValueOrDefault())
			{
				ErrorMessage = "Delete failed. Try again";
			}
			return Page();
		}

		/// <summary>
		/// Ons the post async.
		/// </summary>
		/// <returns>The post async.</returns>
		/// <param name="id">Identifier.</param>
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			_logger.LogDebug($"Printers/Delete/OnPostAsync ({id})");

			if (id == null)
			{
				return NotFound();
			}

			var printer = await _context.Printer
				.AsNoTracking()
				.FirstOrDefaultAsync(p => p.ID == id).ConfigureAwait(false);

			if (printer == null)
			{
				return NotFound();
			}

			try
			{
				_context.Printer.Remove(printer);
				await _context.SaveChangesAsync().ConfigureAwait(false);
				return RedirectToPage("./Index");
			}
			catch (DbUpdateException ex)
			{

				_logger.LogError("Printers/Delete {0}", ex.ToString());

				return RedirectToAction("./Delete",
					new { id, saveChangesError = true });
			}
		}
	}
}

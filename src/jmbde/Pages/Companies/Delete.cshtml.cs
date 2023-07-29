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

namespace JMuelbert.BDE.Pages.Companies
{
	/// <summary>
	/// Delete model.
	/// </summary>
	public class DeleteModel : PageModel
	{ /// <summary>
	  /// The context.
	  /// </summary>
		private readonly BDEContext _context;

		/// <summary>
		/// The logger.
		/// </summary>
		private readonly ILogger _logger;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Companies.DeleteModel"/> class.
		/// </summary>
		/// <param name="logger">Logger.</param>
		/// <param name="context">Context.</param>
		public DeleteModel(ILogger<DeleteModel> logger, BDEContext context)
		{
			_logger = logger;
			_context = context;
		}
		/// <summary>
		/// Gets or sets the cityname.
		/// </summary>
		/// <value>The cityname.</value>
		[BindProperty]
		public Company Company { get; set; }

		/// <summary>
		/// Gets or sets the error message.
		/// </summary>
		/// <value>The error message.</value>
		public string ErrorMessage { get; set; }

		/// <summary>
		/// Ons the get async.
		/// </summary>
		/// <returns>The get async.</returns>
		/// <param name="id">Identifier.</param>
		/// <param name="saveChangesError">Save changes error.</param>
		public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
		{
			_logger.LogDebug($"Companies/Delete/OnGetAsync{id} - {saveChangesError}");

			if (id == null)
			{
				return NotFound();
			}

			Company = await _context.Company
				.AsNoTracking()
				.FirstOrDefaultAsync(c => c.ID == id).ConfigureAwait(false);

			if (Company == null)
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
			_logger.LogDebug($"Companies/Delete/OnPostAsync {id}");

			if (id == null)
			{
				return NotFound();
			}

			var company = await _context.Company
				.AsNoTracking()
				.FirstOrDefaultAsync(c => c.ID == id).ConfigureAwait(false);

			if (company == null)
			{
				return NotFound();
			}

			try
			{
				_context.Company.Remove(company);
				await _context.SaveChangesAsync().ConfigureAwait(false);
				return RedirectToPage("./Index");
			}
			catch (DbUpdateException ex)
			{

				_logger.LogError("Companies/Delete {0}", ex.ToString());
				return RedirectToAction("./Delete",
					new { id, saveChangesError = true });
			}
		}
	}
}

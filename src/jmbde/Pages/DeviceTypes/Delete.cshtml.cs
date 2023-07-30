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

namespace JMuelbert.BDE.Pages.DeviceTypes
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
		/// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.DeviceTypes.IndexModel"/>
		/// class.
		/// </summary>
		/// <param name="logger">Logger.</param>
		/// <param name="context">Context.</param>

		public DeleteModel(Logger<DeleteModel> logger, BDEContext context)
		{
			_logger = logger;
			_context = context;
		}

		/// <summary>
		/// Ons the get.
		/// </summary>
		/// <returns>The get.</returns>
		[BindProperty]
		public DeviceType DeviceType { get; set; }

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
			_logger.LogDebug($"DeviceTypes/Delete/OnGetAsync({id}, {saveChangesError})");
			if (id == null)
			{
				return NotFound();
			}

			DeviceType = await _context.DeviceType.AsNoTracking()
							 .FirstOrDefaultAsync(d => d.ID == id)
							 .ConfigureAwait(false);

			if (DeviceType == null)
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
			_logger.LogDebug($"DeviceTypes/Delete/OnPostAsync ({id})");
			if (id == null)
			{
				return NotFound();
			}

			var devicetype = await _context.DeviceType.AsNoTracking()
								 .FirstOrDefaultAsync(d => d.ID == id)
								 .ConfigureAwait(false);

			if (devicetype == null)
			{
				return NotFound();
			}

			try
			{
				_context.DeviceType.Remove(devicetype);
				await _context.SaveChangesAsync().ConfigureAwait(false);
				return RedirectToPage("./Index");

			}
			catch (DbUpdateException ex)
			{
				_logger.LogError("DeviceName/Delete {0}", ex.ToString());

				return RedirectToAction("./Delete", new { id, saveChangesError = true });
			}
		}
	}
}
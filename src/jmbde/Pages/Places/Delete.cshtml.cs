/**************************************************************************
 **
 ** Copyright (c) 2016-2020 Jürgen Mülbert. All rights reserved.
 **
 ** This file is part of jmbde
 **
 ** Licensed under the EUPL, Version 1.2 or – as soon they
 ** will be approved by the European Commission - subsequent
 ** versions of the EUPL (the "Licence");
 ** You may not use this work except in compliance with the
 ** Licence.
 ** You may obtain a copy of the Licence at:
 **
 ** https://joinup.ec.europa.eu/page/eupl-text-11-12
 **
 ** Unless required by applicable law or agreed to in
 ** writing, software distributed under the Licence is
 ** distributed on an "AS IS" basis,
 ** WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 ** express or implied.
 ** See the Licence for the specific language governing
 ** permissions and limitations under the Licence.
 **
 ** Lizenziert unter der EUPL, Version 1.2 oder - sobald
 **  diese von der Europäischen Kommission genehmigt wurden -
 ** Folgeversionen der EUPL ("Lizenz");
 ** Sie dürfen dieses Werk ausschließlich gemäß
 ** dieser Lizenz nutzen.
 ** Eine Kopie der Lizenz finden Sie hier:
 **
 ** https://joinup.ec.europa.eu/page/eupl-text-11-12
 **
 ** Sofern nicht durch anwendbare Rechtsvorschriften
 ** gefordert oder in schriftlicher Form vereinbart, wird
 ** die unter der Lizenz verbreitete Software "so wie sie
 ** ist", OHNE JEGLICHE GEWÄHRLEISTUNG ODER BEDINGUNGEN -
 ** ausdrücklich oder stillschweigend - verbreitet.
 ** Die sprachspezifischen Genehmigungen und Beschränkungen
 ** unter der Lizenz sind dem Lizenztext zu entnehmen.
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

namespace JMuelbert.BDE.Pages.Places
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
		/// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Places.IndexModel"/> class.
		/// </summary>
		/// <param name="logger">Logger.</param>
		/// <param name="context">Context.</param>

		public DeleteModel(ILogger<DeleteModel> logger, BDEContext context)
		{
			_logger = logger;
			_context = context;
		}

		/// <summary>
		/// Gets or sets the Place.
		/// </summary>
		/// <value>The Place.</value>
		[BindProperty]
		public Place Place { get; set; }

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
			_logger.LogDebug($"Places/Delete/OnGetAsync({ id }, { saveChangesError })");

			if (id == null)
			{
				return NotFound();
			}

			Place = await _context.Place
				.AsNoTracking()
				.FirstOrDefaultAsync(p => p.ID == id).ConfigureAwait(false);

			if (Place == null)
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
			_logger.LogDebug($"Places/Delete/OnPostAsync ({ id })");

			if (id == null)
			{
				return NotFound();
			}

			var place = await _context.Place
				.AsNoTracking()
				.FirstOrDefaultAsync(p => p.ID == id).ConfigureAwait(false);

			if (place == null)
			{
				return NotFound();
			}

			try
			{
				_context.Place.Remove(place);
				await _context.SaveChangesAsync().ConfigureAwait(false);
				return RedirectToPage("./Index");
			}
			catch (DbUpdateException ex)
			{

				_logger.LogError("Places/Delete {0}", ex.ToString());

				return RedirectToAction("./Delete",
					new { id, saveChangesError = true });
			}
		}
	}
}

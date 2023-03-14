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
		/// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.ChipCard.CreateModel"/> class.
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

			if (await TryUpdateModelAsync<ChipCard>(
					emptyChipCard,
					"chipcard", // Prefix for form value.
					c => c.Number,
					c => c.Locked,
					c => c.LastUpdate
				).ConfigureAwait(false))
			{
				_context.ChipCard.Add(emptyChipCard);
				await _context.SaveChangesAsync().ConfigureAwait(false);

				return RedirectToPage("./Index");
			}
			return null;
		}
	}
}

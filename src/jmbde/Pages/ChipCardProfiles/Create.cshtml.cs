/**************************************************************************
 **
 ** SPDX-FileCopyrightText: 2016-2023 Jürgen Mülbert
 ** Copyright (c) 2016-2023 Jürgen Mülbert. All rights reserved.
 ** SPDX-License-Identifier: EUPL-1.2
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

namespace JMuelbert.BDE.Pages.ChipCardProfiles
{
	/// <summary>
	/// CreateModel
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
		/// Gets or sets the chip card profile.
		/// </summary>
		/// <value>The chip card profile.</value>
		[BindProperty]
		public ChipCardProfile ChipCardProfile { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.ChipCardProfiles.CreateModel"/> class.
		/// </summary>
		/// <param name="logger"></param>
		/// <param name="context"></param>
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
			_logger.LogDebug("ChipCardProfiles/Create/OnGet");

			return Page();
		}

		/// <summary>
		/// Ons the post async.
		/// </summary>
		/// <returns>The post async.</returns>
		public async Task<IActionResult> OnPostAsync()
		{
			_logger.LogDebug("ChipCardProfiles/Create/OnPostAsync");

			if (!ModelState.IsValid)
			{
				return Page();
			}

			var emptyChipCardProfile = new ChipCardProfile();

			if (await TryUpdateModelAsync<ChipCardProfile>(
					emptyChipCardProfile,
					"chipcardprofile", // Prefix for form value
					c => c.Number,
					c => c.LastUpdate
				).ConfigureAwait(false))
			{
				_context.ChipCardProfile.Add(emptyChipCardProfile);
				await _context.SaveChangesAsync().ConfigureAwait(false);
				return RedirectToPage("./Index");
			}

			return null;
		}
	}
}

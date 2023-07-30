/**************************************************************************
 **
 ** SPDX-FileCopyrightText: 2016-2023 Jürgen Mülbert
 ** Copyright (c) 2016-2023 Jürgen Mülbert. All rights reserved.
 ** SPDX-License-Identifier: EUPL-1.2
 **
 **************************************************************************/

using System.Threading.Tasks;
using JMuelbert.BDE.Shared.Data;
using JMuelbert.BDE.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace JMuelbert.BDE.Pages.ChipCardDoors
{
	/// <summary>
	/// Details model.
	/// </summary>
	public class DetailsModel : PageModel
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
		/// Localization
		/// </summary>
		private readonly IStringLocalizer<DetailsModel> _localizer;

		///< summary>
		/// Localization
		///</summary>
		private readonly IStringLocalizer<DetailsModel> _sharedLocalizer;

		/// <summary>
		/// Initializes a new instance of the <see
		/// cref="T:JMuelbert.BDE.Pages.ChipCardDoors.DetailsModel"/> class.
		/// </summary>
		/// <param name="logger">Logger.</param>
		/// <param name="localizer">localizer.</param>
		/// <param name="sharedLocalizer">localizer.</param>
		/// <param name="context">Context.</param>
		public DetailsModel(ILogger<DetailsModel> logger, IStringLocalizer<DetailsModel> localizer,
							IStringLocalizer<DetailsModel> sharedLocalizer, BDEContext context)
		{
			_logger = logger;
			_localizer = localizer;
			_sharedLocalizer = sharedLocalizer;
			_context = context;
		}

		/// <summary>
		/// Gets or sets the chip card door.
		/// </summary>
		/// <value>The chip card door.</value>
		public ChipCardDoor ChipCardDoor { get; set; }

		/// <summary>
		/// Ons the get async.
		/// </summary>
		/// <returns>The get async.</returns>
		/// <param name="id">Identifier.</param>
		public async Task<IActionResult> OnGetAsync(int? id)
		{
			_logger.LogDebug($"ChipCardDoors/Details/OnGetAsync ({id})");

			if (id == null)
			{
				return NotFound();
			}

			ChipCardDoor = await _context.ChipCardDoor.Include(c => c.Employee)
							   .Include(d => d.Department)
							   .Include(p => p.Place)
							   .AsNoTracking()
							   .FirstOrDefaultAsync(m => m.ID == id)
							   .ConfigureAwait(false);

			if (ChipCardDoor == null)
			{
				return NotFound();
			}

			return Page();
		}
	}
}
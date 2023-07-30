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

namespace JMuelbert.BDE.Pages.Mobiles
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
		/// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Mobiles.DetailsModel"/>
		/// class.
		/// </summary>
		/// <param name="logger"></param>
		/// <param name="context"></param>

		public DetailsModel(ILogger<DetailsModel> logger, BDEContext context)
		{
			_logger = logger;
			_context = context;
		}

		/// <summary>
		/// Gets or sets the Mobile.
		/// </summary>
		/// <value>The Mobile.</value>
		public Mobile Mobile { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			_logger.LogDebug($"Mobiles/Details/OnGetAsync ({id})");
			if (id == null)
			{
				return NotFound();
			}

			Mobile = await _context.Mobile.SingleOrDefaultAsync(m => m.ID == id).ConfigureAwait(false);

			if (Mobile == null)
			{
				return NotFound();
			}
			return Page();
		}
	}
}
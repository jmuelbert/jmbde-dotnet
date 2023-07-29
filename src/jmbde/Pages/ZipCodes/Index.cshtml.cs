/**************************************************************************
 **
 ** SPDX-FileCopyrightText: 2016-2023 Jürgen Mülbert
 ** Copyright (c) 2016-2023 Jürgen Mülbert. All rights reserved.
 ** SPDX-License-Identifier: EUPL-1.2
 **
 **************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JMuelbert.BDE.Shared.Data;
using JMuelbert.BDE.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace JMuelbert.BDE.Pages.ZipCodes
{
	/// <summary>
	/// Index model.
	/// </summary>
	public class IndexModel : PageModel
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
		/// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.ZipCodes.IndexModel"/> class.
		/// </summary>
		/// <param name="logger">Logger.</param>
		/// <param name="context">Context.</param>

		public IndexModel(ILogger<IndexModel> logger, BDEContext context)
		{
			_logger = logger;
			_context = context;
		}

		/// <summary>
		/// Gets or sets the CodeSort.
		/// </summary>
		/// <value>The CodeSort.</value>
		public string CodeSort { get; set; }

		// TODO: Remove LastUpdate Sort

		/// <summary>
		/// Gets or sets the lastupdate sort.
		/// </summary>
		/// <value>The lastupdate sort.</value>
		public string LastUpdateSort { get; set; }

		/// <summary>
		/// Gets or sets the current filter.
		/// </summary>
		/// <value>The current filter.</value>
		public string CurrentFilter { get; set; }

		/// <summary>
		/// Gets or sets the current sort.
		/// </summary>
		/// <value>The current sort.</value>
		public string CurrentSort { get; set; }

		/// <summary>
		/// Gets or sets the ZipCode.
		/// </summary>
		/// <value>The ZipCode.</value>
		public PaginatedCollection<ZipCode> ZipCode { get; set; }

		public async Task OnGetAsync(string sortOrder,
			string currentFilter, string searchString, int? pageIndex)
		{
			_logger.LogDebug($"ZipCodes/Index/OnGetAsync({currentFilter},{searchString},{pageIndex})");

			CurrentSort = sortOrder;
			CodeSort = String.IsNullOrEmpty(sortOrder) ? "code_desc" : "";
			LastUpdateSort = sortOrder == "LastUpdate" ? "lastupdate_desc" : "LastUpdate";
			if (searchString != null)
			{
				pageIndex = 1;
			}
			else
			{
				searchString = currentFilter;
			}

			CurrentFilter = searchString;

			IQueryable<ZipCode> zipcodeIQ = from z in _context.ZipCode
											select z;

			if (!String.IsNullOrEmpty(searchString))
			{
				zipcodeIQ = zipcodeIQ.Where(zip => zip.Code.Contains(searchString, StringComparison.CurrentCulture));
			}

			switch (sortOrder)
			{
				case "code_desc":
					zipcodeIQ = zipcodeIQ.OrderByDescending(z => z.Code);
					break;

				case "LastUpdate":
					zipcodeIQ = zipcodeIQ.OrderBy(z => z.LastUpdate);
					break;
				case "lastupdate_desc":
					zipcodeIQ = zipcodeIQ.OrderByDescending(z => z.LastUpdate);
					break;

				default:
					zipcodeIQ = zipcodeIQ.OrderBy(z => z.Code);
					break;
			}

			int pageSize = 10;
			ZipCode = await PaginatedCollection<ZipCode>.CreateAsync(
				zipcodeIQ.AsNoTracking(), pageIndex ?? 1, pageSize
			).ConfigureAwait(false);
		}
	}
}

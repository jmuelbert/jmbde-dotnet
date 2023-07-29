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

namespace JMuelbert.BDE.Pages.Faxes
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
		/// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Faxes.IndexModel"/> class.
		/// </summary>
		/// <param name="logger">Logger.</param>
		/// <param name="context">Context.</param>

		public IndexModel(ILogger<IndexModel> logger, BDEContext context)
		{
			_logger = logger;
			_context = context;
		}

		/// <summary>
		/// Gets or sets the NumberSort.
		/// </summary>
		/// <value>The NumberSort.</value>
		public string NumberSort { get; set; }

		/// <summary>
		/// Gets or sets the nActiveSort.
		/// </summary>
		/// <value>The ActiveSort.</value>
		public string ActiveSort { get; set; }

		public string ReplaceSort { get; set; }

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
		/// Gets or sets the Fax.
		/// </summary>
		/// <value>The Fax.</value>
		public PaginatedCollection<Fax> Fax { get; set; }

		public async Task OnGetAsync(string sortOrder,
			string currentFilter, string searchString, int? pageIndex)
		{
			_logger.LogDebug($"Fax/Index/OnGetAsync({currentFilter},{searchString},{pageIndex})");

			CurrentSort = sortOrder;
			NumberSort = String.IsNullOrEmpty(sortOrder) ? "number_desc" : "";
			ActiveSort = sortOrder == "Active" ? "active_desc" : "Active";
			ReplaceSort = sortOrder == "Replace" ? "replace_desc" : "Replace";
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

			IQueryable<Fax> faxIQ = from f in _context.Fax
									select f;

			if (!String.IsNullOrEmpty(searchString))
			{
				faxIQ = faxIQ.Where(fax => fax.Number.Contains(searchString, StringComparison.CurrentCulture));
			}

			switch (sortOrder)
			{
				case "number_desc":
					faxIQ = faxIQ.OrderByDescending(f => f.Number);
					break;

				case "Active":
					faxIQ = faxIQ.OrderBy(f => f.Active);
					break;

				case "active_desc":
					faxIQ = faxIQ.OrderByDescending(f => f.Active);
					break;

				case "Replace":
					faxIQ = faxIQ.OrderBy(f => f.Replace);
					break;

				case "replace_desc":
					faxIQ = faxIQ.OrderByDescending(f => f.Replace);
					break;

				case "LastUpdate":
					faxIQ = faxIQ.OrderBy(f => f.LastUpdate);
					break;
				case "lastupdate_desc":
					faxIQ = faxIQ.OrderByDescending(f => f.LastUpdate);
					break;

				default:
					faxIQ = faxIQ.OrderBy(d => d.Number);
					break;
			}

			int pageSize = 10;
			Fax = await PaginatedCollection<Fax>.CreateAsync(
				faxIQ.AsNoTracking(), pageIndex ?? 1, pageSize
			).ConfigureAwait(false);
		}
	}
}

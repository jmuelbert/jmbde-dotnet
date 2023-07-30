/**************************************************************************
 **
 ** SPDX-FileCopyrightText: © 2016-2023 Jürgen Mülbert
 **
 ** SPDX-License-Identifier: EUPL-1.2
 **
 *************************************************************************/

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

namespace JMuelbert.BDE.Pages.Manufacturers
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
		/// Initializes a new instance of the <see
		/// cref="T:JMuelbert.BDE.Pages.Manufacturers.IndexModel"/> class.
		/// </summary>
		/// <param name="logger">Logger.</param>
		/// <param name="context">Context.</param>

		public IndexModel(ILogger<IndexModel> logger, BDEContext context)
		{
			_logger = logger;
			_context = context;
		}

		/// <summary>
		/// Gets or sets the NameSort.
		/// </summary>
		/// <value>The NameSort.</value>
		public string NameSort { get; set; }

		/// <summary>
		/// Gets or sets the SupportSort.
		/// </summary>
		/// <value>The SupportSort.</value>
		public string SupportSort { get; set; }

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
		/// Gets or sets the Manufacturer.
		/// </summary>
		/// <value>The Manufacturer.</value>
		public PaginatedCollection<Manufacturer> Manufacturer { get; set; }

		/// <summary>
		/// Ons the get async.
		/// </summary>
		/// <param name="sortOrder"></param>
		/// <param name="currentFilter"></param>
		/// <param name="searchString"></param>
		/// <param name="pageIndex"></param>
		public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString,
									 int? pageIndex)
		{
			_logger.LogDebug(
				$"Manufacturers/Index/OnGetAsync({currentFilter},{searchString},{pageIndex})");

			CurrentSort = sortOrder;
			NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
			SupportSort = sortOrder == "Supporter" ? "supporter_desc" : "Supporter";
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

			IQueryable<Manufacturer> manufacturerIQ = from m in _context.Manufacturer select m;

			if (!String.IsNullOrEmpty(searchString))
			{
				manufacturerIQ = manufacturerIQ.Where(
					man => man.Name.Contains(searchString, StringComparison.CurrentCulture));
			}

			switch (sortOrder)
			{
				case "name_desc":
					manufacturerIQ = manufacturerIQ.OrderByDescending(d => d.Name);
					break;

				case "Supporter":
					manufacturerIQ = manufacturerIQ.OrderBy(m => m.Supporter);
					break;

				case "supporter_desc":
					manufacturerIQ = manufacturerIQ.OrderByDescending(m => m.Supporter);
					break;

				case "LastUpdate":
					manufacturerIQ = manufacturerIQ.OrderBy(d => d.LastUpdate);
					break;

				case "lastupdate_desc":
					manufacturerIQ = manufacturerIQ.OrderByDescending(d => d.LastUpdate);
					break;

				default:
					manufacturerIQ = manufacturerIQ.OrderBy(d => d.Name);
					break;
			}

			int pageSize = 10;
			Manufacturer = await PaginatedCollection<Manufacturer>.CreateAsync(
					  manufacturerIQ.AsNoTracking(), pageIndex ?? 1, pageSize
				  ).ConfigureAwait(false);
		}
	}
}
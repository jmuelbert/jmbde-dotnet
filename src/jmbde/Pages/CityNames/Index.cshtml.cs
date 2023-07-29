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

namespace JMuelbert.BDE.Pages.CityNames
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
		/// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.CityNames.IndexModel"/> class.
		/// </summary>
		/// <param name="logger">Logger.</param>
		/// <param name="context">Context.</param>
		public IndexModel(ILogger<IndexModel> logger, BDEContext context)
		{
			_logger = logger;
			_context = context;
		}

		/// <summary>
		/// Gets or sets the name sort.
		/// </summary>
		/// <value>The name sort.</value>
		public string NameSort { get; set; }

		/// <summary>
		/// Gets or sets the date sort.
		/// </summary>
		/// <value>The date sort.</value>
		public string DateSort { get; set; }

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
		/// Gets or sets the cityname profile.
		/// </summary>
		/// <value>The cityname profile.</value>
		public PaginatedCollection<CityName> CityName { get; set; }

		/// <summary>
		/// Ons the get async.
		/// </summary>
		/// <param name="sortOrder"></param>
		/// <param name="currentFilter"></param>
		/// <param name="searchString"></param>
		/// <param name="pageIndex"></param>
		/// <returns></returns>
		public async Task OnGetAsync(string sortOrder,
			string currentFilter, string searchString, int? pageIndex)
		{
			_logger.LogDebug($"CityName/Index/OnGetAsync({currentFilter},{searchString},{pageIndex})");

			CurrentSort = sortOrder;
			NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
			DateSort = sortOrder == "Date" ? "date_desc" : "Date";
			if (searchString != null)
			{
				pageIndex = 1;
			}
			else
			{
				searchString = currentFilter;
			}

			CurrentFilter = searchString;

			IQueryable<CityName> cityNameIQ = from c in _context.CityName
											  select c;

			if (!String.IsNullOrEmpty(searchString))
			{
				cityNameIQ = cityNameIQ.Where(cn => cn.Name.Contains(searchString, StringComparison.CurrentCulture));
			}

			switch (sortOrder)
			{
				case "name_desc":
					cityNameIQ = cityNameIQ.OrderByDescending(c => c.Name);
					break;

				case "Date":
					cityNameIQ = cityNameIQ.OrderBy(c => c.LastUpdate);
					break;

				case "date_desc":
					cityNameIQ = cityNameIQ.OrderByDescending(c => c.LastUpdate);
					break;

				default:
					cityNameIQ = cityNameIQ.OrderBy(c => c.Name);
					break;
			}

			int pageSize = 10;
			CityName = await PaginatedCollection<CityName>.CreateAsync(
				cityNameIQ.AsNoTracking(), pageIndex ?? 1, pageSize
			).ConfigureAwait(false);
		}
	}
}

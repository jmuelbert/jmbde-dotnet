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

namespace JMuelbert.BDE.Pages.DeviceTypes
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
		/// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.DeviceTypes.IndexModel"/> class.
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
		/// Gets or sets the DeviceType profile.
		/// </summary>
		/// <value>The DeviceType profile.</value>
		public PaginatedCollection<DeviceType> DeviceType { get; set; }

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
			_logger.LogDebug($"DeviceType/Index/OnGetAsync({currentFilter},{searchString},{pageIndex})");

			CurrentSort = sortOrder;
			NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
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

			IQueryable<DeviceType> deviceTypeIQ = from d in _context.DeviceType
												  select d;

			if (!String.IsNullOrEmpty(searchString))
			{
				deviceTypeIQ = deviceTypeIQ.Where(dt => dt.Name.Contains(searchString, StringComparison.CurrentCulture));
			}
			switch (sortOrder)
			{
				case "name_desc":
					deviceTypeIQ = deviceTypeIQ.OrderByDescending(d => d.Name);
					break;

				case "LastUpdate":
					deviceTypeIQ = deviceTypeIQ.OrderBy(d => d.LastUpdate);
					break;
				case "lastupdate_desc":
					deviceTypeIQ = deviceTypeIQ.OrderByDescending(d => d.LastUpdate);
					break;

				default:
					deviceTypeIQ = deviceTypeIQ.OrderBy(d => d.Name);
					break;
			}

			int pageSize = 10;
			DeviceType = await PaginatedCollection<DeviceType>.CreateAsync(
				deviceTypeIQ.AsNoTracking(), pageIndex ?? 1, pageSize
			).ConfigureAwait(false);

		}
	}
}

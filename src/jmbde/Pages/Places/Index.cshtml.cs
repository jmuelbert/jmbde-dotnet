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

namespace JMuelbert.BDE.Pages.Places
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
		/// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Places.IndexModel"/> class.
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
		/// Gets or sets the RoomSort.
		/// </summary>
		/// <value>The RoomSort.</value>
		public string RoomSort { get; set; }

		/// <summary>
		/// Gets or sets the DeskSort.
		/// </summary>
		/// <value>The DeskSort.</value>
		public string DeskSort { get; set; }

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
		/// Gets or sets the Place.
		/// </summary>
		/// <value>The Place.</value>
		public PaginatedCollection<Place> Place { get; set; }

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
			_logger.LogDebug($"Places/Index/OnGetAsync({currentFilter},{searchString},{pageIndex})");

			CurrentSort = sortOrder;
			NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
			RoomSort = sortOrder == "Room" ? "room_desc" : "Room";
			DeskSort = sortOrder == "Desk" ? "desk_desc" : "Desk";
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

			IQueryable<Place> placeIQ = from p in _context.Place
										select p;

			if (!String.IsNullOrEmpty(searchString))
			{
				placeIQ = placeIQ.Where(pl => pl.Name.Contains(searchString, StringComparison.CurrentCulture));
			}

			switch (sortOrder)
			{
				case "name_desc":
					placeIQ = placeIQ.OrderByDescending(p => p.Name);
					break;

				case "Room":
					placeIQ = placeIQ.OrderBy(p => p.Room);
					break;

				case "room_desc":
					placeIQ = placeIQ.OrderByDescending(p => p.Room);
					break;

				case "Desk":
					placeIQ = placeIQ.OrderBy(p => p.Desk);
					break;

				case "desk_desc":
					break;

				case "LastUpdate":
					placeIQ = placeIQ.OrderBy(p => p.LastUpdate);
					break;

				case "lastupdate_desc":
					placeIQ = placeIQ.OrderByDescending(p => p.LastUpdate);
					break;

				default:
					placeIQ = placeIQ.OrderBy(p => p.Name);
					break;
			}

			int pageSize = 10;
			Place = await PaginatedCollection<Place>.CreateAsync(
				placeIQ.AsNoTracking(), pageIndex ?? 1, pageSize
			).ConfigureAwait(false);
		}
	}
}

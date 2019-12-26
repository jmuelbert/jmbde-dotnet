/**************************************************************************
 **
 ** Copyright (c) 2016-2019 Jürgen Mülbert. All rights reserved.
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
using System.Linq;
using System.Threading.Tasks;
using JMuelbert.BDE.Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JMuelbert.BDE.Pages.ChipCards {
    /// <summary>
    /// Index model.
    /// </summary>
    public class IndexModel : PageModel {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly JMuelbert.BDE.Data.ApplicationDbContext _context;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.ChipCards.IndexModel"/> class.
        /// </summary>
        /// <param name="logger">Logger.async</param>
        /// <param name="context">Context.</param>
        public IndexModel (ILogger<IndexModel> logger, JMuelbert.BDE.Data.ApplicationDbContext context) {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Gets or sets the number sort.
        /// </summary>
        /// <value>The number sort.</value>
        public string NumberSort { get; set; }

        /// <summary>
        /// Gets or sets the locked sort.
        /// </summary>
        /// <value>The date sort.</value>
        public string LockedSort { get; set; }

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
        /// Gets or sets the chip card.
        /// </summary>
        /// <value>The chip card.</value>
        public PaginatedCollection<ChipCard> ChipCard { get; set; }

        /// <summary>
        /// Ons the get async.
        /// </summary>
        /// <returns>The get async.</returns>
        /// <param name="sortOrder">Sort order.</param>
        /// <param name="currentFilter">Current filter.</param>
        /// <param name="searchString">Search string.</param>
        /// <param name="pageIndex">Page index.</param>
        public async Task OnGetAsync (string sortOrder,
            string currentFilter, string searchString, int? pageIndex) {
            _logger.LogDebug ($"ChipCards/Index/OnGetAsync{currentFilter},{searchString},{pageIndex})");

            CurrentSort = sortOrder;
            NumberSort = String.IsNullOrEmpty (sortOrder) ? "number_desc" : "";
            LockedSort = sortOrder == "Locked" ? "locked_desc" : "Locked";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null) {
                pageIndex = 1;
            } else {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<ChipCard> chipCardIQ = from c in _context.ChipCard
            select c;

            if (!String.IsNullOrEmpty (searchString)) {
                chipCardIQ = chipCardIQ.Where (cc => cc.Number.Contains (searchString, StringComparison.CurrentCulture));
            }

            switch (sortOrder) {
                case "number_desc":
                    chipCardIQ = chipCardIQ.OrderByDescending (c => c.Number);
                    break;
                case "Locked":
                    chipCardIQ = chipCardIQ.OrderBy (c => c.Locked);
                    break;
                case "locked_desc":
                    chipCardIQ = chipCardIQ.OrderByDescending (c => c.Locked);
                    break;
                case "Date":
                    chipCardIQ = chipCardIQ.OrderBy (c => c.LastUpdate);
                    break;
                case "date_desc":
                    chipCardIQ = chipCardIQ.OrderByDescending (c => c.LastUpdate);
                    break;
                default:
                    chipCardIQ = chipCardIQ.OrderBy (c => c.Number);
                    break;
            }

            int pageSize = 10;

            ChipCard = await PaginatedCollection<ChipCard>.CreateAsync (
                chipCardIQ.AsNoTracking (), pageIndex ?? 1, pageSize
            ).ConfigureAwait (false);
        }
    }
}

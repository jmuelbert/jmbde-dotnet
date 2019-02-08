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

namespace JMuelbert.BDE.Pages.Printers {
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
        /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Printers.IndexModel"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="context">Context.</param>

        public IndexModel (ILogger<IndexModel> logger, JMuelbert.BDE.Data.ApplicationDbContext context) {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Gets or sets the NameSort.
        /// </summary>
        /// <value>The NameSort.</value>
        public string NameSort { get; set; }

        /// <summary>
        /// Gets or sets the ActiveSort.
        /// </summary>
        /// <value>The ActiveSort.</value>
        public string ActiveSort { get; set; }

        /// <summary>
        /// Gets or sets the ReplaceSort.
        /// </summary>
        /// <value>The ReplaceSort.</value>
        public string ReplaceSort { get; set; }

        /// <summary>
        /// Gets or sets the PaperSizeSort.
        /// </summary>
        /// <value>The PaperSizeSort.</value>
        public string PaperSizeSort { get; set; }

        /// <summary>
        /// Gets or sets the ColorSort.
        /// </summary>
        /// <value>The ColorSort.</value>
        public string ColorSort { get; set; }

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
        /// Gets or sets the Printer.
        /// </summary>
        /// <value>The Printer.</value>
        public PaginatedList<Printer> Printer { get; set; }

        /// <summary>
        /// Ons the get async.
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="currentFilter"></param>
        /// <param name="searchString"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public async Task OnGetAsync (string sortOrder,
            string currentFilter, string searchString, int? pageIndex) {
            _logger.LogDebug ($"Printers/Index/OnGetAsync({currentFilter},{searchString},{pageIndex})");

            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty (sortOrder) ? "name_desc" : "";
            ActiveSort = sortOrder == "Active" ? "active_desc" : "Active";
            ReplaceSort = sortOrder == "Replace" ? "replace_desc" : "Replace";
            PaperSizeSort = sortOrder == "PaperSize" ? "papersize_desc" : "PaperSize";
            ColorSort = sortOrder == "Color" ? "color_desc" : "Color";
            LastUpdateSort = sortOrder == "LastUpdate" ? "lastupdate_desc" : "LastUpdate";
            if (searchString != null) {
                pageIndex = 1;
            } else {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Printer> printerIQ = from p in _context.Printer
            select p;

            if (!String.IsNullOrEmpty (searchString)) {
                printerIQ = printerIQ.Where (pr => pr.Name.Contains (searchString, StringComparison.CurrentCulture));
            }

            switch (sortOrder) {
                case "name_desc":
                    printerIQ = printerIQ.OrderByDescending (p => p.Name);
                    break;

                case "Active":
                    printerIQ = printerIQ.OrderBy (p => p.Active);
                    break;

                case "active_desc":
                    printerIQ = printerIQ.OrderByDescending (p => p.Active);
                    break;

                case "Replace":
                    printerIQ = printerIQ.OrderBy (p => p.Replace);
                    break;

                case "replace_desc":
                    printerIQ = printerIQ.OrderByDescending (p => p.Replace);
                    break;

                case "PaperSize":
                    printerIQ = printerIQ.OrderBy (p => p.PaperSize);
                    break;

                case "papersize_desc":
                    printerIQ = printerIQ.OrderByDescending (p => p.PaperSize);
                    break;

                case "Color":
                    printerIQ = printerIQ.OrderBy (p => p.Color);
                    break;

                case "color_desc":
                    printerIQ = printerIQ.OrderByDescending (p => p.Color);
                    break;

                case "LastUpdate":
                    printerIQ = printerIQ.OrderBy (p => p.LastUpdate);
                    break;
                case "lastupdate_desc":
                    printerIQ = printerIQ.OrderByDescending (p => p.LastUpdate);
                    break;

                default:
                    printerIQ = printerIQ.OrderBy (p => p.Name);
                    break;
            }

            int pageSize = 10;
            Printer = await PaginatedList<Printer>.CreateAsync (
                printerIQ.AsNoTracking (), pageIndex ?? 1, pageSize
            ).ConfigureAwait (false);
        }
    }
}

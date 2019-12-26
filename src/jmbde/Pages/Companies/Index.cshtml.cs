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

namespace JMuelbert.BDE.Pages.Companies {
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
        /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Companies.IndexModel"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="context">Context.</param>;
        public IndexModel (ILogger<IndexModel> logger, JMuelbert.BDE.Data.ApplicationDbContext context) {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Gets or sets the name sort.
        /// </summary>
        /// <value>The name sort.</value>
        public string NameSort { get; set; }

        /// <summary>
        /// Gets or sets the name2 sort.
        /// </summary>
        /// <value>The name2 sort.</value>
        public string Name2Sort { get; set; }

        /// <summary>
        /// Gets or sets the active sort.
        /// </summary>
        /// <value>The active sort.</value>
        public string ActiveSort { get; set; }

        // TODO: Remove this
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
        /// Gets or sets the cityname profile.
        /// </summary>
        /// <value>The cityname profile.</value>
        public PaginatedCollection<Company> Company { get; set; }

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
            _logger.LogDebug ($"Companies/Index/OnGetAsync({currentFilter},{searchString},{pageIndex})");

            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty (sortOrder) ? "name_desc" : "";
            Name2Sort = sortOrder == "Name2" ? "name2_desc" : "Name2";
            ActiveSort = sortOrder == "Active" ? "active_desc" : "Active";
            LastUpdateSort = sortOrder == "LastUpdate" ? "lastupdate_desc" : "LastUpdate";
            if (searchString != null) {
                pageIndex = 1;
            } else {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Company> companyIQ = from c in _context.Company
            select c;

            if (!String.IsNullOrEmpty (searchString)) {
                companyIQ = companyIQ.Where (com => com.Name.Contains (searchString, StringComparison.CurrentCulture));
            }

            switch (sortOrder) {
                case "name_desc":
                    companyIQ = companyIQ.OrderByDescending (c => c.Name);
                    break;

                case "Name2":
                    companyIQ = companyIQ.OrderBy (c => c.Name2);
                    break;
                case "name2_desc":
                    companyIQ = companyIQ.OrderByDescending (c => c.Name2);
                    break;

                case "Active":
                    companyIQ = companyIQ.OrderBy (c => c.Active);
                    break;

                case "active_desc":
                    companyIQ = companyIQ.OrderByDescending (c => c.Active);
                    break;

                case "LastUpdate":
                    companyIQ = companyIQ.OrderBy (c => c.LastUpdate);
                    break;

                case "lastupdate_desc":
                    companyIQ = companyIQ.OrderByDescending (c => c.LastUpdate);
                    break;

                default:
                    companyIQ = companyIQ.OrderBy (c => c.Name);
                    break;
            }

            int pageSize = 10;
            Company = await PaginatedCollection<Company>.CreateAsync (
                companyIQ.AsNoTracking (), pageIndex ?? 1, pageSize
            ).ConfigureAwait (false);
        }
    }
}

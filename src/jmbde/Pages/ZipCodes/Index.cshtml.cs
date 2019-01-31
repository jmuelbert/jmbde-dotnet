/**************************************************************************
 **
 ** Copyright (c) 2016-2018 Jürgen Mülbert. All rights reserved.
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

namespace JMuelbert.BDE.Pages.ZipCodes {
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
        /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.ZipCodes.IndexModel"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="context">Context.</param>

        public IndexModel (ILogger<IndexModel> logger, JMuelbert.BDE.Data.ApplicationDbContext context) {
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
        public PaginatedList<ZipCode> ZipCode { get; set; }

        public async Task OnGetAsync (string sortOrder,
            string currentFilter, string searchString, int? pageIndex) {
            _logger.LogDebug ("ZipCodes/Index/OnGetAsync");

            CurrentSort = sortOrder;
            CodeSort = String.IsNullOrEmpty (sortOrder) ? "code_desc" : "";
            LastUpdateSort = sortOrder == "LastUpdate" ? "lastupdate_desc" : "LastUpdate";
            if (searchString != null) {
                pageIndex = 1;
            } else {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<ZipCode> zipcodeIQ = from z in _context.ZipCode
            select z;

            if (!String.IsNullOrEmpty (searchString)) {
                zipcodeIQ = zipcodeIQ.Where (zip => zip.Code.Contains (searchString));
            }

            switch (sortOrder) {
                case "code_desc":
                    zipcodeIQ = zipcodeIQ.OrderByDescending (z => z.Code);
                    break;

                case "LastUpdate":
                    zipcodeIQ = zipcodeIQ.OrderBy (z => z.LastUpdate);
                    break;
                case "lastupdate_desc":
                    zipcodeIQ = zipcodeIQ.OrderByDescending (z => z.LastUpdate);
                    break;

                default:
                    zipcodeIQ = zipcodeIQ.OrderBy (z => z.Code);
                    break;
            }

            int pageSize = 10;
            ZipCode = await PaginatedList<ZipCode>.CreateAsync (
                zipcodeIQ.AsNoTracking (), pageIndex ?? 1, pageSize
            );
        }
    }
}

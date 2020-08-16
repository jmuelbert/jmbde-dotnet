/**************************************************************************
 **
 ** Copyright (c) 2016-2020 Jürgen Mülbert. All rights reserved.
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

using JMuelbert.BDE.Shared.Data;
using JMuelbert.BDE.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMuelbert.BDE.Pages.Employees {
    /// <summary>
    /// Index model.
    /// </summary>
    public class IndexModel : PageModel {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly BDEContext _context;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Employees.IndexModel"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="context">Context.</param>

        public IndexModel (ILogger<IndexModel> logger, BDEContext context) {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Gets or sets the EmployeeIdentSort.
        /// </summary>
        /// <value>The EmployeeIdentSort.</value>
        public string EmployeeIdentSort { get; set; }

        /// <summary>
        /// Gets or sets the GenderSort.
        /// </summary>
        /// <value>The GenderSort.</value>
        public string GenderSort { get; set; }

        /// <summary>
        /// Gets or sets the NameSort.
        /// </summary>
        /// <value>The NameSort.</value>
        public string NameSort { get; set; }

        /// <summary>
        /// Gets or sets the BirthDaySort.
        /// </summary>
        /// <value>The BirthDaySort.</value>
        public string BirthDaySort {  get; set; }

        /// <summary>
        /// Gets or sets the DataCareSort.
        /// </summary>
        /// <value>The DataCareSort.</value>
        public string DataCareSort { get; set; }

        /// <summary>
        /// Gets or sets the ActiveSort.
        /// </summary>
        /// <value>The ActiveSort.</value>
        public string ActiveSort { get; set; }

        /// <summary>
        /// Gets or sets the HireDateSort.
        /// </summary>
        /// <value>The HireDateSort.</value>
        public string HireDateSort { get; set; }

        /// <summary>
        /// Gets or sets the EndDateSort.
        /// </summary>
        /// <value>The EndDateSort.</value>
        public string EndDateSort { get; set; }

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
        /// Gets or sets the Employee.
        /// </summary>
        /// <value>The Employee.</value>
        public PaginatedCollection<Employee> Employee { get; set; }

        /// <summary>
        /// Ons the get async.
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="currentFilter"></param>
        /// <param name="searchString"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public async Task OnGetAsync (string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            _logger.LogDebug ($"Employees/Index/OnGetAsync({currentFilter},{searchString},{pageIndex})");

            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty (sortOrder) ? "name_desc" : "";
            EmployeeIdentSort = sortOrder == "EmployeeIdent" ? "employeeident_desc" : "EmployeeIdent";
            GenderSort = sortOrder == "Gender" ? "gender_desc" : "Gender";
            BirthDaySort = sortOrder == "BirthDay" ? "birthday_desc" : "BirthDay";
            DataCareSort = sortOrder == "DataCare" ? "datacare_desc" : "DataCare";
            ActiveSort = sortOrder == "Active" ? "active_desc" : "Active";
            HireDateSort = sortOrder == "HireDate" ? "hiredate_desc" : "HireDate";
            EndDateSort = sortOrder == "EndDate" ? "enddate_desc" : "EndDate";
            LastUpdateSort = sortOrder == "LastUpdate" ? "lastupdate_desc" : "LastUpdate";
            if (searchString != null) {
                pageIndex = 1;
            } else {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Employee> employeeIQ = from e in _context.Employee
                .Include(e => e.Department)
            select e;

            if (!String.IsNullOrEmpty (searchString)) {
                employeeIQ = employeeIQ.Where (e => e.LastName.Contains (searchString, StringComparison.CurrentCulture));
            }
            switch (sortOrder) {
                case "name_desc":
                    employeeIQ = employeeIQ.OrderByDescending (e => e.LastName);
                    break;

                case "EmployeeIdent":
                    employeeIQ = employeeIQ.OrderBy (e => e.EmployeeIdent);
                    break;

                case "employeeident_desc":
                    employeeIQ = employeeIQ.OrderByDescending (e => e.EmployeeIdent);
                    break;

                case "Gender":
                    employeeIQ = employeeIQ.OrderBy (e => e.Gender);
                    break;

                case "gender_desc":
                    employeeIQ = employeeIQ.OrderByDescending (e => e.Gender);
                    break;

                case "BirthDay":
                    employeeIQ = employeeIQ.OrderBy (e => e.BirthDay);
                    break;

                case "birthday_desc":
                    employeeIQ = employeeIQ.OrderByDescending (e => e.BirthDay);
                    break;

                case "DataCare":
                    employeeIQ = employeeIQ.OrderBy (e => e.DataCare);
                    break;

                case "datacare_desc":
                    employeeIQ = employeeIQ.OrderByDescending (e => e.DataCare);
                    break;

                case "Active":
                    employeeIQ = employeeIQ.OrderBy (e => e.IsActive);
                    break;

                case "active_desc":
                    employeeIQ = employeeIQ.OrderByDescending (e => e.IsActive);
                    break;

                case "HireDate":
                    employeeIQ = employeeIQ.OrderBy (e => e.HireDate);
                    break;

                case "hiredate_desc":
                    employeeIQ = employeeIQ.OrderByDescending (e => e.HireDate);
                    break;

                case "EndDate":
                    employeeIQ = employeeIQ.OrderBy (e => e.EndDate);
                    break;

                case "enddate_desc":
                    employeeIQ = employeeIQ.OrderByDescending (e => e.EndDate);
                    break;

                case "LastUpdate":
                    employeeIQ = employeeIQ.OrderBy (d => d.LastUpdate);
                    break;

                case "lastupdate_desc":
                    employeeIQ = employeeIQ.OrderByDescending (d => d.LastUpdate);
                    break;

                default:
                    employeeIQ = employeeIQ.OrderBy (d => d.LastName);
                    break;
            }

            int pageSize = 10;
            Employee = await PaginatedCollection<Employee>.CreateAsync (
                employeeIQ.AsNoTracking (), pageIndex ?? 1, pageSize
            ).ConfigureAwait (false);
        }
    }
}

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

using System.Threading.Tasks;
using JMuelbert.BDE.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace JMuelbert.BDE.Pages.Employees {
    /// <summary>
    /// Create model.
    /// </summary>
    public class CreateModel : PageModel {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly JMuelbert.BDE.Data.ApplicationDbContext _context;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Employees.IndexModel"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="context">Context.</param>

        public CreateModel (ILogger<CreateModel> logger, JMuelbert.BDE.Data.ApplicationDbContext context) {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Ons the get.
        /// </summary>
        /// <returns>The get.</returns>
        public IActionResult OnGet () {
            return Page ();
        }

        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>The employee.</value>
        [BindProperty]
        public Employee Employee { get; set; }

        /// <summary>
        /// Ons the get async.
        /// </summary>
        /// <returns>The get async.</returns>
        public async Task<IActionResult> OnPostAsync () {
            _logger.LogDebug ("Employees/Create/OnGet");
            if (!ModelState.IsValid) {
                return Page ();
            }

            var emptyEmployee = new Employee ();

            if (await TryUpdateModelAsync<Employee> (
                    emptyEmployee,
                    "employee", // Prefix for form value
                    e => e.EmployeeIdent,
                    e => e.FirstName,
                    e => e.LastName,
                    e => e.BirthDay,
                    e => e.Street,
                    e => e.HomePhone,
                    e => e.HomeMobile,
                    e => e.HomeMailAddress,
                    e => e.BusinessMailAddress,
                    e => e.DataCare,
                    e => e.Active,
                    e => e.Photo,
                    e => e.Notes,
                    e => e.HireDate,
                    e => e.EndDate,
                    e => e.LastUpdate
                ).ConfigureAwait (false)) {
                _context.Employee.Add (emptyEmployee);
                await _context.SaveChangesAsync ().ConfigureAwait (false);

                return RedirectToPage ("./Index");
            }
            return null;
        }
    }
}

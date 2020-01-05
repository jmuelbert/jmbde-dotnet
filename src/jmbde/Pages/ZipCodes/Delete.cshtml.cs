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

using System;
using System.Threading.Tasks;
using JMuelbert.BDE.Shared.Data;
using JMuelbert.BDE.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace JMuelbert.BDE.Pages.ZipCodes {
    /// <summary>
    /// Delete model.
    /// </summary>
    public class DeleteModel : PageModel {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly BDEContext _context;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.ZipCodes.IndexModel"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="context">Context.</param>

        public DeleteModel (ILogger<DeleteModel> logger, BDEContext context) {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Gets or sets the ZipCode.
        /// </summary>
        /// <value>The ZipCode.</value>
        [BindProperty]
        public ZipCode ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the ErrorMessage.
        /// </summary>
        /// <value>The ErrorMessage.</value>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Ons the get async.
        /// </summary>
        /// <returns>The get async.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="saveChangesError">Save changes error.</param>
        public async Task<IActionResult> OnGetAsync (int? id, bool? saveChangesError = false) {
            _logger.LogDebug ($"ZipCodes/Delete/OnGetAsync({ id }, { saveChangesError })");

            if (id == null) {
                return NotFound ();
            }

            ZipCode = await _context.ZipCode
                .AsNoTracking ()
                .FirstOrDefaultAsync (z => z.ID == id).ConfigureAwait (false);

            if (ZipCode == null) {
                return NotFound ();
            }

            if (saveChangesError.GetValueOrDefault ()) {
                ErrorMessage = "Delete failed. Try again";
            }
            return Page ();
        }

        /// <summary>
        /// Ons the post async.
        /// </summary>
        /// <returns>The post async.</returns>
        /// <param name="id">Identifier.</param>
        public async Task<IActionResult> OnPostAsync (int? id) {
            _logger.LogDebug ($"ZipCodes/Delete/OnPostAsync ({ id })");

            if (id == null) {
                return NotFound ();
            }

            var zipcode = await _context.ZipCode
                .AsNoTracking ()
                .FirstOrDefaultAsync (z => z.ID == id).ConfigureAwait (false);

            if (zipcode == null) {
                return NotFound ();
            }

            try {
                _context.ZipCode.Remove (zipcode);
                await _context.SaveChangesAsync ().ConfigureAwait (false);
                return RedirectToPage ("./Index");
            } catch (DbUpdateException ex) {

                _logger.LogError ("ZipCodes/Delete {0}", ex.ToString ());

                return RedirectToAction ("./Delete",
                    new { id, saveChangesError = true });
            }
        }
    }
}

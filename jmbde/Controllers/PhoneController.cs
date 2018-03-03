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

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using jmbde.Data;
using jmbde.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace jmbde.Controllers
{
    /// <summary>
    /// The Employee-Controller
    /// </summary>
    public class PhoneController : Controller
    {
        /// <summary>
        /// The Context Variable
        /// </summary>
        private readonly JMBDEContext _context;

        /// <summary>
        /// ctor for the Controller
        /// </summary>
        /// <param name="context"></param>
        public PhoneController(JMBDEContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Phone.ToListAsync());
        }

        /// <summary>
        /// View Details
        /// </summary>
        /// <param name="id"></param>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.Phone
                        .AsNoTracking()
                     .SingleOrDefaultAsync(m => m.PhoneId == id);

            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        /// <summary>
        /// GET: Phone/Create
        /// </summary>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        ///POST: Phone/Create
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Number")] Phone phone)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(phone);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException /* ex */)
            {
                // Log the error (uncomment ex variable name and write a log.)
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            return View(phone);
        }

        /// <summary>
        /// GET: Mobile/Edit
        /// </summary>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.Phone.SingleOrDefaultAsync(m => m.PhoneId == id);
            if (phone == null)
            {
                return NotFound();
            }
            return View(phone);
        }

        /// <summary>
        /// POST: Phone/Edit
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var phoneToUpdate = await _context.Phone.SingleOrDefaultAsync(e => e.PhoneId == id);
            if (await TryUpdateModelAsync<Phone>(
                phoneToUpdate,
                "",
                m => m.Number))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    // Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes." +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(phoneToUpdate);
        }

        ///<summary>
        /// GET: Phone/Delete
        /// </summary>
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.Phone
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.PhoneId == id);
            if (phone == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if problem persists " +
                    "see your system administrator.";
            }

            return View(phone);
        }

        /// <summary>
        /// POST: Phone/Delete
        /// </summary>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phone = await _context.Phone
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.PhoneId == id);
            if (phone == null)
            {
                RedirectToAction("Index");
            }

            try
            {
                _context.Phone.Remove(phone);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
        }

        private bool PhoneExists(int id)
        {
            return _context.Phone.Any(e => e.PhoneId == id);
        }
    }

}

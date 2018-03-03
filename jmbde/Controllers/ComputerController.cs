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
    /// The Computer-Controller
    /// </summary>
    public class ComputerController : Controller
    {
        /// <summary>
        /// The Context Variable
        /// </summary>
        private readonly JMBDEContext _context;

        /// <summary>
        /// ctor for the Controller
        /// </summary>
        /// <param name="context"></param>
        public ComputerController(JMBDEContext context) 
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
           return View(await _context.Computer.ToListAsync());
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

          var computer = await _context.Computer
              .AsNoTracking()
              .SingleOrDefaultAsync(c => c.ComputerId == id);

            if (computer == null)
            {
              return NotFound();
            }

            return View(computer);
        }

        /// <summary>
        /// GET: Computer/Create
        /// </summary>
        public IActionResult Create()
        {
          return View();
        }

        /// <summary>
        /// POST: Computer/Create
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
          [Bind("NetworkName")] Computer computer)
          {
            try
            {
                if (ModelState.IsValid)
                {
                  _context.Add(computer);
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

            return View(computer);
          }

        /// <summary>
        /// GET: Computer/Edit
        /// </summary>
        public async Task<IActionResult> Edit(int? id)
        {
          if (id == null)
          {
            return NotFound();
          }

          var computer = await _context.Computer.SingleOrDefaultAsync(c => c.ComputerId == id);
          if (computer == null)
          {
            return NotFound();
          }
          return View(computer);
        }
        /// <summary>
        /// POST: Computer/Edit
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
          var computerToUpdate = await _context.Computer.SingleOrDefaultAsync(c => c.ComputerId == id);
          if (await TryUpdateModelAsync<Computer>(
            computerToUpdate,
            "",
            c => c.NetworkName,
            c => c.Active))
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
            return View(computerToUpdate);
        }

        /// <summary>
        /// GET: Computer/Delete
        /// </summary>
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
          if (id == null)
          {
            return NotFound();
          }

          var computer = await _context.Computer
            .AsNoTracking()
            .SingleOrDefaultAsync(c => c.ComputerId == id);

          if (computer == null)
          {
            return NotFound();
          }

          if (saveChangesError.GetValueOrDefault())
          {
            ViewData["ErrorMessage"] =
              "Delete failed. Try again, and if problem persists " +
              "see your system administrator.";
          }
          return View(computer);
        }

        /// <summary>
        /// POST: Computer/Delete
        /// </summary>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
          var computer = await _context.Computer
            .AsNoTracking()
            .SingleOrDefaultAsync(c => c.ComputerId == id);

          if (computer == null)
          {
            RedirectToAction("Index");
          }

          try
          {
              _context.Computer.Remove(computer);
              await _context.SaveChangesAsync();
              return RedirectToAction("Index");
          }
          catch (DbUpdateException /* ex */)
          {
            //Log the error (uncomment ex variable name and write a log.)
            return RedirectToAction("Delete", new { id = id, saveChangesError = true });
          }
        }

        private bool ComputerExists(int id)
        {
          return _context.Computer.Any(c => c.ComputerId == id);
        }
    }
}

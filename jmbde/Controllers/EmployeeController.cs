/*
 * Copyright 2016 Jürgen Mülbert
 *
 * Licensed under the EUPL, Version 1.1 or – as soon they
   will be approved by the European Commission - subsequent
   versions of the EUPL (the "Licence");
 * You may not use this work except in compliance with the Licence.
 * You may obtain a copy of the Licence at:
 *
 * https://joinup.ec.europa.eu/software/page/eupl5
 *
 * Unless required by applicable law or agreed to in
   writing, software distributed under the Licence is
   distributed on an "AS IS" basis,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
   express or implied.
 * See the Licence for the specific language governing
  permissions and limitations under the Licence.
*/

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
    public class EmployeeController : Controller
    {
        /// <summary>
        /// The Context Variable
        /// </summary>
        private readonly JMBDEContext _context;

        /// <summary>
        /// ctor for the Controller
        /// </summary>
        /// <param name="context"></param>
        public EmployeeController(JMBDEContext context) 
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Employee.ToListAsync());
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

            var employee = await _context.Employee
                .Include(e => e.Computers)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        /// <summary>
        /// GET: Employee/Create
        /// </summary>
        public IActionResult Create()
        {
            return View();
        }
        
        /// <summary>
        ///POST: Employee:Create
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("EmployeeNO,FirstName,Name")] Employee employee)
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    _context.Add(employee);
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

            return View(employee);
        }

        /// <summary>
        /// GET: Employee/Edit
        /// </summary>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.SingleOrDefaultAsync(m => m.ID == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        /// <summary>
        /// POST: Employee/Edit
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
            var employeeToUpdate = await _context.Employee.SingleOrDefaultAsync(e => e.ID == id);
            if (await TryUpdateModelAsync<Employee>(
                employeeToUpdate,
                "",
                s => s.FirstName, s => s.Name))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch(DbUpdateException /* ex */)
                {
                    // Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes." +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(employeeToUpdate);
        }

        ///<summary>
        /// GET: Employee/Delete
        /// </summary>
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (employee == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if problem persists " +
                    "see your system administrator.";
            }

            return View(employee);
        } 

        /// <summary>
        /// POST: Employee/Delete
        /// </summary>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (employee == null)
            {
                RedirectToAction("Index");
            }

            try
            {
                _context.Employee.Remove(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException /* ex */)
            {
               //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any( e => e.ID == id);
        }
    }

}

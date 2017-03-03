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

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using jmbde.Data;

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
        private jmbdesqliteContext _context;

        /// <summary>
        /// ctor for the Controller
        /// </summary>
        /// <param name="context"></param>
        public ComputerController(jmbdesqliteContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// GET: /<controller>/
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Index()
        {   
            var computers = _context.Computer
                .Include(c => c.Employee)
                .OrderBy(c => c.NetworkName);

            return View(computers);
        }

        /// <summary>
        /// Details
        /// </summary>
        /// Show Computer Details
        /// <param name="id"></param>
        /// <returns>View</returns>
        public async Task<ActionResult> Details(int id)
        {
            Computer computer = await _context.Computer
                .Include(c => c.Employee)
                .SingleOrDefaultAsync( c => c.EmployeeId == id);

            return View(computer);
        }

        /// <summary>
        /// Create Action
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            ViewBag.Items = GetAddressSetItems();
            return View();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="[Bind("></param>
        /// <param name=""Name""></param>
        /// <param name=""Active""></param>
        /// <param name=""EmployeeId")"></param>
        /// <param name="computer"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NetworkName", "Active", "EmployeeId")] Computer computer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Computer.Add(computer);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (System.Exception)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return View(computer);
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int id)
        {
            Computer computer = await FindComputerAsync(id);
            ViewBag.Items = GetAddressSetItems((int ) computer.EmployeeId);

            return View(computer);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="[Bind("></param>
        /// <param name=""Name""></param>
        /// <param name=""Active""></param>
        /// <param name=""EmployeeId")"></param>
        /// <param name="computer"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("NetworkName", "Active", "EmployeeId")] Computer computer)
        {
            try
            {
                computer.ComputerId = id;
                _context.Computer.Attach(computer);
                _context.Entry(computer).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return View(computer);
        }

        /// <summary>
        /// ConfirmDelete
        /// </summary>
        /// <param name="retry"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id, bool? retry)
        {
            Computer computer = await FindComputerAsync(id);
            ViewBag.retry = retry ?? false;
            return View(computer);
        }


        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Computer computer = await FindComputerAsync(id);
                _context.Computer.Remove(computer);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                return RedirectToAction("Delete", new { id = id, retry = true});
            }
            return RedirectToAction("Index");
        }

        #region Helpers
           /// <summary>
            ///  GetAddressSetItems
            /// </summary>
            /// <param name="selected"></param>
            /// <returns></returns>
            private IEnumerable<SelectListItem> GetAddressSetItems(int selected = -1)
            {            
                var tmp = _context.Employee.ToList();
                // Create Addresses list for <select> dropbox
                return tmp
                    .OrderBy(employee => employee.Lastname)
                    .Select(employee => new SelectListItem
                    {
                        Text = $"{employee.Lastname}, {employee.Firstname}",
                        Value = employee.EmployeeId.ToString(),
                        Selected = employee.EmployeeId == selected
                    });
            }

            /// <summary>
            /// FindEmployeeAsync
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            private Task<Computer> FindComputerAsync(int id)
            {
                return _context.Computer
                    .SingleOrDefaultAsync(computer => computer.ComputerId == id);
            }    
        #endregion
    }
}

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Data.Entity;

using jmbde.Models;
using Microsoft.AspNet.Mvc.Rendering;



// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace jmbde.Controllers
{
    /// <summary>
    /// The ComputerController
    /// </summary>
    public class ComputerController : Controller
    {
        [FromServices]
        public JMBDEContext JMBDEContext { get; set; }

        [FromServices]
        public ILogger<CompanyController> Logger { get; set; }

        /// <summary>
        // GET: /<controller>
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var computers = JMBDEContext.Computer
                .Include(c => c.Employee)
                .OrderBy(c => c.Name);

            return View(computers);
        }

        /// <summary>
        /// Details
        /// </summary>
        /// Show Computer-Details
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Details(int id)
        {
            Computer computers = await JMBDEContext.Computer
                .Include(c => c.Employee)
                .SingleOrDefaultAsync(c => c.Id == id);
            if (computers == null)
            {
                Logger.LogInformation("Details: Item not found {0}", id);
                return HttpNotFound();
            }
            return View(computers);
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ViewBag.Items = GetEmployeeListItems();
            return View();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Name", "Active", "EmployeeId")] Computer computer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    JMBDEContext.Computer.Add(computer);
                    await JMBDEContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return View(computer);
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="id"></param>
        public async Task<ActionResult> Edit(int id)
        {
            Computer computer = await FindComputerAsync(id);
            if (computer == null)
            {
                Logger.LogInformation("Edit: Item not found {0}", id);
                return HttpNotFound();
            }
            ViewBag.Items = GetEmployeeListItems(computer.EmployeeId);
            return View(computer);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, [Bind("Name", "Active", "EmployeeId")] Computer computer)
        {
            try
            {
                computer.Id = id;
                JMBDEContext.Computer.Attach(computer);
                JMBDEContext.Entry(computer).State = EntityState.Modified;
                await JMBDEContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return View(computer);
        }

        /// <summary>
        /// ConfirmDelete
        /// </summary>
        /// <param name="id"></param>
        /// <param name="retry"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("Delete")]
        public async Task<ActionResult> ConfirmDelete(int id, bool? retry)
        {
            Computer computer = await FindComputerAsync(id);
            if (computer == null)
            {
                Logger.LogInformation("Delete: Item not found {0}", id);
                return HttpNotFound();
            }
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
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Computer computer = await FindComputerAsync(id);
                JMBDEContext.Computer.Remove(computer);
                await JMBDEContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                return RedirectToAction("Delete", new { id = id, retry = true });
            }
            return RedirectToAction("Index");
        }

        #region Helpers
        /// <summary>
        /// GetAddressSetItems
        /// </summary>
        //// <returns>A List of AddressSets</returns>
        private IEnumerable<SelectListItem> GetEmployeeListItems(int selected = -1)
        {
            // Workaround for https://gethub.com/aspnet/EntityFramework/issies/2246
            var tmp = JMBDEContext.Employee.ToList();

            // Create Addresses list for <select> dropbox
            return tmp
                .OrderBy(employee => employee.Name)
                .Select(employee => new SelectListItem
                {
                    Text = String.Format("{0}, {1}", employee.Name, employee.FirstName),
                    Value = employee.Id.ToString(),
                    Selected = employee.Id == selected
                });
        }


        /// <summary>
        /// FindComputerAsync
        /// </summary>
        /// <param name="id"></name>
        /// <return></returns>
        private Task<Computer> FindComputerAsync(int id)
        {
            return JMBDEContext.Computer
                .SingleOrDefaultAsync(Computer => Computer.Id == id);
        }
        #endregion
    }
}

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
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;

using jmbde.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace jmbde.Controllers
{
    /// <summary>
    /// The Company Controller
    /// </summary>
    public class CompanyController : Controller
    {
        [FromServices]
        public JMBDEContext JMBDEContext { get; set; }

        [FromServices]
        public ILogger<CompanyController> Logger { get; set; }

        /// <summary>
        // GET: /<controller>/
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var companies = JMBDEContext.Company.OrderBy(c => c.Name);
            return View(companies);
        }

        /// <summary>
        /// Details
        /// </summary>
        /// Show Company Details
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Details(int id)
        {
            Company company = await FindCompanyAsync(id);
            if (company == null)
            {
                Logger.LogInformation("Details: Item not found {0}", id);
                return HttpNotFound();
            }
            return View(company);
        }

        /// <summary>
        /// Create
        /// </summary>
        /// Create a new entry for a Company
        /// <returns></returns>
        public ActionResult Create()
        {
            ViewBag.Items = GetEmployeeListItems();
            return View();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Name", "Name2", "EmployeeId")] Company company)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    JMBDEContext.Company.Add(company);
                    await JMBDEContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return View(company);
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// Edit an company Entry
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Edit(int id)
        {
            Company company = await FindCompanyAsync(id);
            if (company == null)
            {
                Logger.LogInformation("Edit: Item not found {0}", id);
                return HttpNotFound();
            }
            ViewBag.Items = GetEmployeeListItems(company.EmployeeId);
            return View(company);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// Update an company entry
        /// <param name="id"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, [Bind("Name", "Name2", "EmployeeId")] Company company)
        {
            try
            {
                company.Id = id;
                JMBDEContext.Company.Attach(company);
                JMBDEContext.Entry(company).State = Microsoft.Data.Entity.EntityState.Modified;
                await JMBDEContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return View(company);
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
            Company company = await FindCompanyAsync(id);
            if (company == null)
            {
                Logger.LogInformation("Delete: Item not found {0}", id);
                return HttpNotFound();
            }
            ViewBag.retry = retry ?? false;
            return View(company);
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
                Company company = await FindCompanyAsync(id);
                JMBDEContext.Company.Remove(company);
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
        /// GetEmployeeListItems
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
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
        /// FindCompanyAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private Task<Company> FindCompanyAsync(int id)
        {
            return JMBDEContext.Company
                .SingleOrDefaultAsync(Company => Company.Id == id);
        }
        #endregion
    }
}

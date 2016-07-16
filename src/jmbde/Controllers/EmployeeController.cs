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
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Data.Entity;
using jmbde.Models;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860


namespace jmbde.Controllers
{
    /// <summary>
	/// The EmployeeController
	/// </summary>
    public class EmployeeController : Controller
    {
        [FromServices]
        public JMBDEContext JMBDEContext { get; set; }

        [FromServices]
        public ILogger<EmployeeController> Logger { get; set; }

        /// <summary>
        /// GET: /<Controller>/
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var employees = JMBDEContext.Employee
                .OrderBy(c => c.Name);

            return View(employees);
        }

        /// <summary>
        /// Details
        /// </summary>
        /// Show Employee-Details
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Details(int id)
        {
            Employee employee = await FindEmployeeAsync(id);
            if (employee == null)
            {
                Logger.LogInformation("Details: Item not found {0}", id);
                return HttpNotFound();
            }
            return View(employee);
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            // ViewBag.Items = GetAddressSetItems();
            return View();
        }


        /// <summary>
        /// Create
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("EmployeeNO", "FirstName", "Name", "BusinessMail",
                         "ChipCard", "DataCare", "Active")] Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    JMBDEContext.Employee.Add(employee);
                    await JMBDEContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (System.Exception)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return View(employee);
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="id"></param>
        public async Task<ActionResult> Edit(int id)
        {
            Employee employee = await FindEmployeeAsync(id);
            if (employee == null)
            {
                Logger.LogInformation("Edit: Item not found {0}", id);
                return HttpNotFound();
            }
            // ViewBag.Items = GetAddressSetItems(employee.AddressSet.Id);
            return View(employee);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, [Bind("EmployeeNO", "FirstName", "Name", "BusinessMail",
                         "ChipCard", "DataCare", "Active")] Employee employee)
        {
            try
            {
                employee.Id = id;
                JMBDEContext.Employee.Attach(employee);
                JMBDEContext.Entry(employee).State = EntityState.Modified;
                await JMBDEContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return View(employee);
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
            Employee employee = await FindEmployeeAsync(id);
            if (employee == null)
            {
                Logger.LogInformation("Delete: Item not found {0}", id);
                return HttpNotFound();
            }
            ViewBag.retry = retry ?? false;
            return View(employee);
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
                Employee employee = await FindEmployeeAsync(id);
                JMBDEContext.Employee.Remove(employee);
                await JMBDEContext.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                return RedirectToAction("Delete", new { id = id, retry = true });
            }
            return RedirectToAction("Index");
        }

        #region Helpers

        /// <summary>
        /// GetAddressSetItems
        /// </summary>
        /* <returns>A List of AddressSets</returns>
        private IEnumerable<SelectListItem> GetAddressSetItems(int selected = -1)
        {
            // Workaround for https://gethub.com/aspnet/EntityFramework/issies/2246
            var tmp = JMBDEContext.AddressSet.ToList();

            // Create Addresses list for <select> dropbox
            return tmp
                .OrderBy(addr => addr.Zip)
                .OrderBy(addr => addr.City)
                .OrderBy(addr => addr.Street)
                .Select(addr => new SelectListItem
                {
                    Text = String.Format("{0} - {1}, {2}", addr.Zip, addr.City, addr.Street),
                    Value = addr.Id.ToString(),
                    Selected = addr.Id == selected
                });
        }
        */

        /// <summary>
        /// FindEmployeeAsync
        /// </summary>
        /// <param name="id"></name>
        /// <return></returns>
        private Task<Employee> FindEmployeeAsync(int id)
        {
            return JMBDEContext.Employee
                .SingleOrDefaultAsync(employee => employee.Id == id);
        }
        #endregion
    }
}

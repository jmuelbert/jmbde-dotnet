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
using Microsoft.AspNet.Mvc.Rendering;

using jmbde.Models;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace jmbde.Controllers
{
    /// <summary>
	/// The MobileController
	/// </summary>
    public class MobileController : Controller
    {
        [FromServices]
        public JMBDEContext JMBDEContext { get; set; }

        [FromServices]
        public ILogger<MobileController> Logger { get; set; }

        /// <summary>
        /// GET: /<Controller>/
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var mobiles = JMBDEContext.Mobile
                .OrderBy(c => c.Number)
                 .Include(c => c.Employee);

            return View(mobiles);
        }

        /// <summary>
        /// Details
        /// </summary>
        /// Show Mobile-Details
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Details(int id)
        {
            Mobile mobile = await JMBDEContext.Mobile
                .Include(c => c.Employee)
                .SingleOrDefaultAsync(c => c.Id == id);
            if (mobile == null)
            {
                Logger.LogInformation("Details: Item not found {0}", id);
                return HttpNotFound();
            }
            return View(mobile);
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
        public async Task<ActionResult> Create([Bind("Number", "EmployeeId")] Mobile mobile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    JMBDEContext.Mobile.Add(mobile);
                    await JMBDEContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (System.Exception)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return View(mobile);
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="id"></param>
        public async Task<ActionResult> Edit(int id)
        {
            Mobile mobile = await FindMobileAsync(id);
            if (mobile == null)
            {
                Logger.LogInformation("Edit: Item not found {0}", id);
                return HttpNotFound();
            }
            ViewBag.Items = GetEmployeeListItems(mobile.EmployeeId);
            return View(mobile);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, [Bind("Number", "EmployeeId")] Mobile mobile)
        {
            try
            {
                mobile.Id = id;
                JMBDEContext.Mobile.Attach(mobile);
                JMBDEContext.Entry(mobile).State = EntityState.Modified;
                await JMBDEContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return View(mobile);
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
            Mobile Mobile = await FindMobileAsync(id);
            if (Mobile == null)
            {
                Logger.LogInformation("Delete: Item not found {0}", id);
                return HttpNotFound();
            }
            ViewBag.retry = retry ?? false;
            return View(Mobile);
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
                Mobile mobile = await FindMobileAsync(id);
                JMBDEContext.Mobile.Remove(mobile);
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
        /// FindMobileAsync
        /// </summary>
        /// <param name="id"></name>
        /// <return></returns>
        private Task<Mobile> FindMobileAsync(int id)
        {
            return JMBDEContext.Mobile
                .SingleOrDefaultAsync(Mobile => Mobile.Id == id);
        }
        #endregion
    }
}

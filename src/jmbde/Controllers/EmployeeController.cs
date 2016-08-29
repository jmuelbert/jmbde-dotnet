<<<<<<< HEAD
﻿/*
=======
/*
>>>>>>> origin/newver
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

<<<<<<< HEAD
=======
using System;
using System.Collections.Generic;
>>>>>>> origin/newver
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
        private JMBDEContext _context;

        /// <summary>
        /// ctor for the Controller
        /// </summary>
        /// <param name="context"></param>
        public EmployeeController(JMBDEContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// GET: /<controller>/
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Index()
        {   
            var employees = _context.Employee
                .OrderBy(c => c.Name);
            return View(employees);
        }

        /// <summary>
        /// Details
        /// </summary>
        /// Show Employee Details
        /// <param name="id"></param>
        /// <returns>View</returns>
        public async Task<ActionResult> Details(int id)
        {
            Employee employee = await FindEmployeeAsync(id);
            return View(employee);
        }

        /// <summary>
        /// Create Action
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name=""EmployeeNO""></param>
        /// <param name=""FirstName""></param>
        /// <param name=""Name""></param>
        /// <param name=""BusinessMail""></param>
        /// <param name=""ChipCard""></param>
        /// <param name=""DataCare""></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeNO", "FirstName", "Name", "BusinessMail",
            "ChipCard", "DataCare", "Active")] Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Employee.Add(employee);
                    await _context.SaveChangesAsync();
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
        /// <returns></returns>
        public async Task<IActionResult> Edit(int id)
        {
            Employee employee = await FindEmployeeAsync(id);
            return View(employee);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="[Bind("EmployeeNO""></param>
        /// <param name=""FirstName""></param>
        /// <param name=""Name""></param>
        /// <param name=""BusinessMail""></param>
        /// <param name=""ChipCard""></param>
        /// <param name=""DataCare""></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("EmployeeNO", "FirstName", "Name", "BusinessMail",
            "ChipCard", "DataCare", "Active")] Employee employee)
        {
            try
            {
                employee.Id = id;
                _context.Employee.Attach(employee);
                _context.Entry(employee).State = EntityState.Modified;
                await _context.SaveChangesAsync();
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
        /// <param name="retry"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id, bool? retry)
        {
            Employee employee = await FindEmployeeAsync(id);
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
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Employee employee = await FindEmployeeAsync(id);
                _context.Employee.Remove(employee);
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
            // private IEnumerable<SelectListItem> GetAddressSetItems(int selected = -1)
            // {
            //    // Workaround for https://github.com/aspnet/EntityFramework/issues/2246
            //    var tmp = _context.AddressSet.Tolist();
            //
            //    // Create Addresses list for <select> dropbox
            //    return tmp
            //        .OrderBy(addr => addr.Zip)
            //        .OrderBy(addr => addr.City)
            //        .OrderBy(addr => addr.Street)
            //        .Select(addr => new SelectListItem
            //        {
            //            Text = $"{0} - {1}, {2}", addr.Zip, addr.City, addr.Street),
            //            Value = addr.Id.ToString(),
            //            Selected = addr.Id == selected
            //        });
            // }

            /// <summary>
            /// FindEmployeeAsync
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            private Task<Employee> FindEmployeeAsync(int id)
            {
                return _context.Employee
                    .SingleOrDefaultAsync(employee => employee.Id == id);
            }    
        #endregion
    }
}

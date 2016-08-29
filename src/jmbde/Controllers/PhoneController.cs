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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using jmbde.Data;
using jmbde.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace jmbde.Controllers
{
    /// <summary>
    /// The Phone-Controller
    /// </summary>
    public class PhoneController : Controller
    {
        /// <summary>
        /// The Context Variable
        /// </summary>
        private JMBDEContext _context;

        /// <summary>
        /// ctor for the Controller
        /// </summary>
        /// <param name="context"></param>
        public PhoneController(JMBDEContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// GET: /<controller>/
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Index()
        {   
            var phones = _context.Phone
                .Include(p => p.Employee)
                .OrderBy(p => p.Number);

            return View(phones);
        }

        /// <summary>
        /// Details
        /// </summary>
        /// Show Employee Details
        /// <param name="id"></param>
        /// <returns>View</returns>
        public async Task<ActionResult> Details(int id)
        {
            Phone phone = await _context.Phone 
                .Include(p => p.Employee)
                .SingleOrDefaultAsync(c => c.Id == id);

            return View(phone);
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
        /// <param name=""Number""></param>
        /// <param name=""EmployeeId""></param>
        /// <param name=""Active")"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Number", "EmployeeId", "Active")] Phone phone)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Phone.Add(phone);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (System.Exception)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return View(phone);
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int id)
        {
            Phone phone = await FindPhoneAsync(id);
            ViewBag.Items = GetAddressSetItems(phone.EmployeeId);

            return View(phone);
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="[Bind("></param> 
        /// <param name=""Number""></param>
        /// <param name=""EmployeeId""></param>
        /// <param name=""Active")"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("Number", "EmployeeId", "Active")] Phone phone)
        {
            try
            {
                phone.Id = id;
                _context.Phone.Attach(phone);
                _context.Entry(phone).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return View(phone);
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
            Phone phone = await FindPhoneAsync(id);
            ViewBag.retry = retry ?? false;
            return View(phone);
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
                Phone phone = await FindPhoneAsync(id);
                _context.Phone.Remove(phone);
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
                    .OrderBy(employee => employee.Name)
                    .Select(employee => new SelectListItem
                    {
                        Text = $"{employee.Name}, {employee.FirstName}",
                        Value = employee.Id.ToString(),
                        Selected = employee.Id == selected
                    });
            }

            /// <summary>
            /// FindEmployeeAsync
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            private Task<Phone> FindPhoneAsync(int id)
            {
                return _context.Phone
                    .SingleOrDefaultAsync(phone => phone.Id == id);
            }    
        #endregion
    }
}

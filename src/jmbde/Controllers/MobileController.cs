
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
using Microsoft.Extensions.Localization;

using jmbde.Data;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace jmbde.Controllers
{
    /// <summary>
    /// The Mobile-Controller
    /// </summary>
    public class MobileController : Controller
    {
        /// <summary>
        /// The Context Variable
        /// </summary>
        private jmbdesqliteContext _context;

        /// <summary>
        /// Localization
        /// </summary>
        private readonly IStringLocalizer <MobileController> _localizer;


        /// <summary>
        /// ctor for the Controller
        /// </summary>
        /// <param name="context"></param>
        public MobileController(jmbdesqliteContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// GET: /<controller>/
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Index()
        {   
            var mobiles = _context.Mobile
                .Include(m => m.Employee)
                .OrderBy(m => m.Number);
            return View(mobiles);
        }

        /// <summary>
        /// Details
        /// </summary>
        /// Show Employee Details
        /// <param name="id"></param>
        /// <returns>View</returns>
        public async Task<ActionResult> Details(int id)
        {
            Mobile mobile = await _context.Mobile
                .Include(m => m.Employee)
                .SingleOrDefaultAsync(m => m.MobileId == id);

            return View(mobile);
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
        /// <param name="mobile"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Number", "EmployeeId", "Active")] Mobile mobile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Mobile.Add(mobile);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (System.Exception)
            {
                ModelState.AddModelError(string.Empty, _localizer["Unable to save changes."]);
            }
            return View(mobile);
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int id)
        {
            Mobile mobile = await FindMobileAsync(id);
            ViewBag.Items = GetAddressSetItems((int ) mobile.EmployeeId);

            return View(mobile);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="[Bind("></param>>
        /// <param name=""Number""></param>
        /// <param name=""EmployeeId""></param>
        /// <param name=""Active")"></param>
        /// <param name="mobile"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("Number", "EmployeeId", "Active")] Mobile mobile)
        {
            try
            {
                mobile.MobileId = id;
                _context.Mobile.Attach(mobile);
                _context.Entry(mobile).State = EntityState.Modified;
                await _context.SaveChangesAsync();
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
        /// <param name="retry"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id, bool? retry)
        {
            Mobile mobile = await FindMobileAsync(id);
            ViewBag.retry = retry ?? false;
            return View(mobile);
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
                Mobile mobile = await FindMobileAsync(id);
                _context.Mobile.Remove(mobile);
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
            private Task<Mobile> FindMobileAsync(int id)
            {
                return _context.Mobile
                    .SingleOrDefaultAsync(mobile => mobile.MobileId == id);
            }    
        #endregion
    }
}

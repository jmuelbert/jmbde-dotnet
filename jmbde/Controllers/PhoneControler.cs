using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Storage;
using Microsoft.Extensions.Logging;
using jmbde.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace jmbde.Controllers
{
    /// <summary>
	/// The PhoneController
	/// </summary>
    public class PhoneController : Controller
    {
        [FromServices]
        public JMBDEContext JMBDEContext { get; set; }
        
        [FromServices]
        public ILogger<PhoneController> Logger { get; set; }
        
		/// <summary>
		/// GET: /<Controller>/
		/// </summary>
		/// <returns></returns>
        public IActionResult Index()
        {
            var Phones = JMBDEContext.Phone;
            return View(Phones);
        }
        
        /// <summary>
        /// Details
        /// </summary>
        /// Show Phone-Details
        /// <param name="id"></param>
        /// <returns></returns>
 	    public async Task<ActionResult> Details(int id)
        {
            Phone Phone = await FindPhoneAsync(id);
            if (Phone == null) {
                Logger.LogInformation("Details: Item not found {0}", id);
                return HttpNotFound();
            }
            return View(Phone);    
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
        public async Task<ActionResult> Create([Bind("Number")] Phone Phone) 
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    JMBDEContext.Phone.Add(Phone);
                    await JMBDEContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (System.Exception)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return View(Phone);
        }
        
        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="id"></param>
        public async Task<ActionResult> Edit(int id)
        {
            Phone Phone = await FindPhoneAsync(id);
            if (Phone == null)
            {
                Logger.LogInformation("Edit: Item not found {0}", id);
                return HttpNotFound();
            }
            // ViewBag.Items = GetAddressSetItems(Phone.AddressSet.Id);
            return View(Phone);
        }
       
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, [Bind("Number")] Phone Phone)
        {
            try
            {
                Phone.Id = id;
                JMBDEContext.Phone.Attach(Phone);
                JMBDEContext.Entry(Phone).State = EntityState.Modified;
                await JMBDEContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return View(Phone);
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
            Phone Phone = await FindPhoneAsync(id);
            if (Phone == null)
            {
                Logger.LogInformation("Delete: Item not found {0}", id);
                return HttpNotFound();
            }
            ViewBag.retry = retry ?? false;
            return View(Phone);
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
                Phone Phone = await FindPhoneAsync(id);
                JMBDEContext.Phone.Remove(Phone);
                await JMBDEContext.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                return RedirectToAction("Delete", new { id = id, retry = true});
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
        /// FindPhoneAsync
        /// </summary>
        /// <param name="id"></name>
        /// <return></returns>
        private Task<Phone> FindPhoneAsync(int id)
        {
            return JMBDEContext.Phone
                .SingleOrDefaultAsync(Phone => Phone.Id == id);
        }
        #endregion
    }
}

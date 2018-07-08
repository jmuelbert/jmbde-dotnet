using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public string EmployeeIdentSort { get; set; }
        public string GenderSort { get; set; }
        public string NameSort { get; set; }
        public string BirthDaySort { get; set; }
        public string DataCareSort { get; set; }
        public string ActiveSort { get; set; }
        public string HireDateSort { get; set; }
        public string EndDateSort { get; set; }
        public string LastUpdateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Employee> Employee { get;set; }

      public async Task OnGetAsync(string sortOrder, 
                string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            EmployeeIdentSort = sortOrder == "EmployeeIdent" ? "employeeident_desc" : "EmployeeIdent";
            GenderSort = sortOrder == "Gender" ? "gender_desc" : "Gender";
            BirthDaySort = sortOrder == "BirthDay" ? "birthday_desc" : "BirthDay";
            DataCareSort = sortOrder == "DataCare" ? "datacare_desc" : "DataCare";
            ActiveSort = sortOrder == "Active" ? "active_desc" : "Active";
            HireDateSort = sortOrder == "HireDate" ? "hiredate_desc" : "HireDate";
            EndDateSort = sortOrder == "EndDate" ? "enddate_desc" : "EndDate";
            LastUpdateSort = sortOrder == "LastUpdate" ? "lastupdate_desc" : "LastUpdate";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Employee> employeeIQ = from e in _context.Employee
                            select e;

            if (!String.IsNullOrEmpty(searchString))
            {
                employeeIQ = employeeIQ.Where(e => e.LastName.Contains(searchString));
            }
              switch (sortOrder)
           {
                case "name_desc":
                    employeeIQ = employeeIQ.OrderByDescending(e => e.LastName);
                    break;

                case "EmployeeIdent":
                    employeeIQ = employeeIQ.OrderBy(e => e.EmployeeIdent);
                    break;

                case "employeeident_desc":
                    employeeIQ = employeeIQ.OrderByDescending(e => e.EmployeeIdent);
                    break;

                case "Gender":
                    employeeIQ = employeeIQ.OrderBy(e => e.Gender);
                    break;

                case "gender_desc":
                    employeeIQ = employeeIQ.OrderByDescending(e => e.Gender);
                    break;

                case "BirthDay":
                    employeeIQ = employeeIQ.OrderBy(e => e.BirthDay);
                    break;

                case "birthday_desc":
                    employeeIQ = employeeIQ.OrderByDescending(e => e.BirthDay);
                    break;

                case "DataCare":
                    employeeIQ = employeeIQ.OrderBy(e => e.DataCare);
                    break;

                case "datacare_desc":
                    employeeIQ = employeeIQ.OrderByDescending(e => e.DataCare);
                    break;

                case "Active":
                    employeeIQ = employeeIQ.OrderBy(e => e.Active);
                    break;
                
                case "active_desc":
                    employeeIQ = employeeIQ.OrderByDescending(e => e.Active);
                    break;

                case "HireDate":
                    employeeIQ = employeeIQ.OrderBy(e => e.HireDate);
                    break;

                case "hiredate_desc":
                    employeeIQ = employeeIQ.OrderByDescending(e => e.HireDate);
                    break;

                case "EndDate":
                    employeeIQ = employeeIQ.OrderBy(e => e.EndDate);
                    break;

                case "enddate_desc":
                    employeeIQ = employeeIQ.OrderByDescending(e => e.EndDate);
                    break;

                case "LastUpdate":
                    employeeIQ = employeeIQ.OrderBy(d => d.LastUpdate);
                    break;
                    
                case "lastupdate_desc":
                    employeeIQ = employeeIQ.OrderByDescending(d => d.LastUpdate);
                    break;

                default:
                    employeeIQ = employeeIQ.OrderBy(d => d.LastName);
                    break;
           }

           int pageSize = 10;
           Employee = await PaginatedList<Employee>.CreateAsync(
               employeeIQ.AsNoTracking(), pageIndex ?? 1, pageSize
           );
        }
    }
}

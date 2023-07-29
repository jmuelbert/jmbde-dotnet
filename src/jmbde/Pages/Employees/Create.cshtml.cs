/**************************************************************************
 **
 ** SPDX-FileCopyrightText: 2016-2023 Jürgen Mülbert
 ** Copyright (c) 2016-2023 Jürgen Mülbert. All rights reserved.
 ** SPDX-License-Identifier: EUPL-1.2
 **
 **************************************************************************/

using System;
using System.Threading.Tasks;
using JMuelbert.BDE.Shared.Data;
using JMuelbert.BDE.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace JMuelbert.BDE.Pages.Employees {
  /// <summary>
  /// Create model.
  /// </summary>
  public class CreateModel : PageModel {
    /// <summary>
    /// The context.
    /// </summary>
    private readonly BDEContext _context;

    /// <summary>
    /// The logger.
    /// </summary>
    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Employees.IndexModel"/>
    /// class.
    /// </summary>
    /// <param name="logger">Logger.</param>
    /// <param name="context">Context.</param>

    public CreateModel(ILogger<CreateModel> logger, BDEContext context) {
      _logger = logger;
      _context = context;
    }

    /// <summary>
    /// Ons the get.
    /// </summary>
    /// <returns>The get.</returns>
    public IActionResult OnGet() {
      return Page();
    }

    /// <summary>
    /// Gets or sets the employee.
    /// </summary>
    /// <value>The employee.</value>
    [BindProperty]
    public Employee Employee { get; set; }

    /// <summary>
    /// Ons the get async.
    /// </summary>
    /// <returns>The get async.</returns>
    public async Task<IActionResult> OnPostAsync() {
      _logger.LogDebug("Employees/Create/OnGet");
      if (!ModelState.IsValid) {
        return Page();
      }

      var emptyEmployee = new Employee();

      if (await TryUpdateModelAsync<Employee>(
              emptyEmployee,
              "employee",  // Prefix for form value
              e => e.EmployeeIdent, e => e.FirstName, e => e.LastName, e => e.BirthDay,
              e => e.Street, e => e.HomePhone, e => e.HomeMobile, e => e.HomeMailAddress,
              e => e.BusinessMailAddress, e => e.DataCare, e => e.IsActive, e => e.Photo,
              e => e.Notes, e => e.HireDate, e => e.EndDate, e => e.LastUpdate)
              .ConfigureAwait(false)) {
        _context.Employee.Add(emptyEmployee);
        await _context.SaveChangesAsync().ConfigureAwait(false);

        return RedirectToPage("./Index");
      }
      return null;
    }
  }
}

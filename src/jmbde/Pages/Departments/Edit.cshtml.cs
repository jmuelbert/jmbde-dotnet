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

namespace JMuelbert.BDE.Pages.Departments {
  /// <summary>
  /// Edit model.
  /// </summary>
  public class EditModel : PageModel {
    /// <summary>
    /// The context.
    /// </summary>
    private readonly BDEContext _context;

    /// <summary>
    /// The logger.
    /// </summary>
    private readonly ILogger _logger;
    /// <summary>
    /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Departments.EditModel"/>
    /// class.
    /// </summary>
    /// <param name="logger">Logger.</param>
    /// <param name="context">Context.</param>

    public EditModel(ILogger<EditModel> logger, BDEContext context) {
      _logger = logger;
      _context = context;
    }

    /// <summary>
    /// Gets or sets the department^.
    /// </summary>
    /// <value>The department.</value>
    [BindProperty]
    public Department Department { get; set; }

    /// <summary>
    /// Ons the get async.
    /// </summary>
    /// <returns>The get async.</returns>
    /// <param name="id">Identifier.</param>
    public async Task<IActionResult> OnGetAsync(int? id) {
      _logger.LogDebug($"Department/Edit/OnGetAsync({id})");

      if (id == null) {
        return NotFound();
      }

      Department = await _context.Department.FindAsync(id).ConfigureAwait(false);

      if (Department == null) {
        return NotFound();
      }
      return Page();
    }

    /// <summary>
    /// OnPostAsync
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> OnPostAsync(int? id) {
      _logger.LogDebug($"Department/Edit/OnPostAsync({id})");

      if (!ModelState.IsValid) {
        return Page();
      }

      var departmentToUpdate = await _context.Department.FindAsync(id).ConfigureAwait(false);

      if (await TryUpdateModelAsync<Department>(departmentToUpdate,
                                                "department",  // Prefix fpr form value
                                                d => d.Name, d => d.Priority, d => d.LastUpdate)
              .ConfigureAwait(false)) {
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return RedirectToPage("./Index");
      }
      return Page();
    }
  }
}

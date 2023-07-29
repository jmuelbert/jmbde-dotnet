/**************************************************************************
 **
 ** SPDX-FileCopyrightText: 2016-2023 Jürgen Mülbert
 ** Copyright (c) 2016-2023 Jürgen Mülbert. All rights reserved.
 ** SPDX-License-Identifier: EUPL-1.2
 **
 **************************************************************************/

using System.Threading.Tasks;
using JMuelbert.BDE.Shared.Data;
using JMuelbert.BDE.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace JMuelbert.BDE.Pages.ChipCardDoors {
  /// <summary>
  /// Delete model.
  /// </summary>
  public class DeleteModel : PageModel {
    /// <summary>
    /// The context.
    /// </summary>
    private readonly BDEContext _context;

    /// <summary>
    /// The logger.
    /// </summary>
    private readonly ILogger _logger;

    /// <summary>
    /// Localization
    /// </summary>
    private readonly IStringLocalizer<CreateModel> _localizer;

    /// <summary>
    /// Localization
    /// </summary>
    private readonly IStringLocalizer<CreateModel> _sharedLocalizer;
    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="T:JMuelbert.BDE.Pages.ChipCardDoors.DeleteModel"/> class.
    /// </summary>
    /// <param name="logger">Logger.</param>
    /// <param name="localizer">localizer.</param>
    /// <param name="sharedLocalizer">localizer.</param>
    /// <param name="context">Context.</param>
    public DeleteModel(ILogger<CreateModel> logger, IStringLocalizer<CreateModel> localizer,
                       IStringLocalizer<CreateModel> sharedLocalizer, BDEContext context) {
      _logger = logger;
      _localizer = localizer;
      _sharedLocalizer = sharedLocalizer;
      _context = context;
    }

    /// <summary>
    /// Gets or sets the chip card door.
    /// </summary>
    /// <value>The chip card door.</value>
    [BindProperty]
    public ChipCardDoor ChipCardDoor { get; set; }

    /// <summary>
    /// Gets or sets the error message.
    /// </summary>
    /// <value>The error message.</value>
    public string ErrorMessage { get; set; }

    /// <summary>
    /// Ons the get async.
    /// </summary>
    /// <returns>The get async.</returns>
    /// <param name="id">Identifier.</param>
    /// <param name="saveChangesError">Save changes error.</param>
    public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false) {
      _logger.LogDebug($"ChipCardDoors/Delete/OnGetAsync({id}, {saveChangesError})");

      if (id == null) {
        return NotFound();
      }

      ChipCardDoor = await _context.ChipCardDoor.AsNoTracking()
                         .FirstOrDefaultAsync(m => m.ID == id)
                         .ConfigureAwait(false);

      if (ChipCardDoor == null) {
        return NotFound();
      }

      if (saveChangesError.GetValueOrDefault()) {
        this.ErrorMessage = "Delete failed. Try again";
      }

      return Page();
    }

    /// <summary>
    /// Ons the post async.
    /// </summary>
    /// <returns>The post async.</returns>
    /// <param name="id">Identifier.</param>
    public async Task<IActionResult> OnPostAsync(int? id) {
      _logger.LogDebug($"ChipCardDoors/Delete/OnPostAsync ({id})");

      if (id == null) {
        return NotFound();
      }

      var chipcarddoor = await _context.ChipCardDoor.AsNoTracking()
                             .FirstOrDefaultAsync(m => m.ID == id)
                             .ConfigureAwait(false);

      if (chipcarddoor == null) {
        return NotFound();
      }

      try {
        _context.ChipCardDoor.Remove(chipcarddoor);
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return RedirectToPage("./Index");
      } catch (DbUpdateException ex) {
        _logger.LogError("ChipCardDoors/Delete {0}", ex.ToString());

        return RedirectToAction("./Delete", new { id, saveChangesError = true });
      }
    }
  }
}

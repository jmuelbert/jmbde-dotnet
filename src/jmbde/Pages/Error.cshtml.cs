/**************************************************************************
 **
 ** SPDX-FileCopyrightText: 2016-2023 Jürgen Mülbert
 ** Copyright (c) 2016-2023 Jürgen Mülbert. All rights reserved.
 ** SPDX-License-Identifier: EUPL-1.2
 **
 **************************************************************************/

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace JMuelbert.BDE.Pages {

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

  /// <summary>
  /// ErrorModel.
  /// </summary>
  public class ErrorModel : PageModel {
    /// <summary>
    /// The logger.
    /// </summary>
    private readonly ILogger logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.ErrorModel"/> class.
    /// </summary>
    /// <param name="logger">Logger.</param>
    public ErrorModel(ILogger<ErrorModel> logger) {
      this.logger = logger;
    }

    /// <summary>
    /// Gets or sets the request identifier.
    /// </summary>
    /// <value>The request identifier.</value>
    public string RequestId { get; set; }

    /// <summary>
    /// Gets a value indicating whether this <see cref="T:JMBde.Pages.ErrorModel"/> show request
    /// identifier.
    /// </summary>
    /// <value><c>true</c> if show request identifier; otherwise, <c>false</c>.</value>
    public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);

    /// <summary>
    /// Ons the get.
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public void OnGet() {
      this.logger.LogDebug("Error/OnGet");
      this.RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
    }
  }
}

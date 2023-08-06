/**************************************************************************
 **
 ** SPDX-FileCopyrightText: © 2016-2023 Jürgen Mülbert
 **
 ** SPDX-License-Identifier: EUPL-1.2
 **
 *************************************************************************/
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace JMuelbert.BDE.Pages
{
    /// <summary>
    /// Privacy model.
    /// </summary>
    public class PrivacyModel : PageModel
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger<PrivacyModel> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.PrivacyModel"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Ons the get.
        /// </summary>
        public void OnGet()
        {
            _logger.LogDebug("PrivacyModel/OnGet");
        }
    }
}
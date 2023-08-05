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
    /// Index model.
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.IndexModel"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        /// <summary>
        /// Ons the get.
        /// </summary>
        public void OnGet()
        {
            _logger.LogDebug("IndexModel/OnGet");
            this.Message = "Your application index page.";
        }
    }
}
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
    /// Contact model.
    /// </summary>
    public class ContactModel : PageModel
    {
        private readonly ILogger logger;

        public ContactModel(ILogger<ContactModel> logger)
        {
            this.logger = logger;
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
            this.Message = "Your contact page.";
            this.logger.LogDebug("Contact/OnGet");
        }
    }
}
/**************************************************************************
 **
 ** SPDX-FileCopyrightText: © 2016-2023 Jürgen Mülbert
 **
 ** SPDX-License-Identifier: EUPL-1.2
 **
 *************************************************************************/

namespace JMuelbert.BDE.Shared.Models
{
    /// <summary>
    /// Error view model.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Gets or sets the request identifier.
        /// </summary>
        /// <value>The request identifier.</value>
        public string RequestId { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see
        /// cref="T:JMuelbert.BDE.Data.Models.ErrorViewModel"/> show request identifier.
        /// </summary>
        /// <value><c>true</c> if show request identifier; otherwise, <c>false</c>.</value>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
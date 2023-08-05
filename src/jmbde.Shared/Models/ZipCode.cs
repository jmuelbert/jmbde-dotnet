/**************************************************************************
 **
 ** SPDX-FileCopyrightText: © 2016-2023 Jürgen Mülbert
 **
 ** SPDX-License-Identifier: EUPL-1.2
 **
 *************************************************************************/
using System;
using System.ComponentModel.DataAnnotations;

namespace JMuelbert.BDE.Shared.Models
{
    /// <summary>
    /// Zip code.
    /// </summary>
    public partial class ZipCode
    {
        /// <summary>
        /// Gets or sets the zip code identifier.
        /// </summary>
        /// <value>The zip code identifier.</value>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
                      MinimumLength = 5)]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
                      MinimumLength = 5)]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the last update.
        /// </summary>
        /// <value>The last update.</value>
        [DataType(DataType.DateTime)]
        public DateTime LastUpdate { get; set; }
    }
}
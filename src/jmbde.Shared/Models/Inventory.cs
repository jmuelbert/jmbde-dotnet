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
    /// Inventory.
    /// </summary>
    public partial class Inventory
    {
        /// <summary>
        /// Gets or sets the inventory identifier.
        /// </summary>
        /// <value>The inventory identifier.</value>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
                      MinimumLength = 5)]
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [StringLength(100,
                      ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
                      MinimumLength = 5)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see
        /// cref="T:JMuelbert.BDE.Data.Models.Inventory"/> is active.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the last update.
        /// </summary>
        /// <value>The last update.</value>
        [DataType(DataType.DateTime)]
        public DateTime LastUpdate { get; set; }
    }
}
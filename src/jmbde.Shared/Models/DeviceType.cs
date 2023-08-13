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
    /// Device type.
    /// </summary>
    public partial class DeviceType
    {
        /// <summary>
        /// Gets or sets the device type identifier.
        /// </summary>
        /// <value>The device type identifier.</value>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
                      MinimumLength = 5)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the last update.
        /// </summary>
        /// <value>The last update.</value>
        [DataType(DataType.DateTime)]
        public DateTime LastUpdate { get; set; }
    }
}
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
    /// Mobile.
    /// </summary>
    public partial class Mobile
    {
        /// <summary>
        /// Gets or sets the mobile identifier.
        /// </summary>
        /// <value>The mobile identifier.</value>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>The number.</value>
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
                      MinimumLength = 5)]
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the serial number.
        /// </summary>
        /// <value>The serial number.</value>
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
                      MinimumLength = 5)]
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the pin.
        /// </summary>
        /// <value>The pin.</value>
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
                      MinimumLength = 5)]
        public string Pin { get; set; }

        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        /// <value>The card number.</value>
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
                      MinimumLength = 5)]
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see
        /// cref="T:JMuelbert.BDE.Data.Models.Mobile"/> is active.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see
        /// cref="T:JMuelbert.BDE.Data.Models.Mobile"/> is replace.
        /// </summary>
        /// <value><c>true</c> if replace; otherwise, <c>false</c>.</value>
        public bool Replace { get; set; }

        /// <summary>
        /// Gets or sets the name of the device.
        /// </summary>
        /// <value>The name of the device.</value>
        public DeviceName DeviceName { get; set; }

        /// <summary>
        /// Gets or sets the type of the device.
        /// </summary>
        /// <value>The type of the device.</value>
        public DeviceType DeviceType { get; set; }

        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>The employee.</value>
        /// public Employee Employee { get; set; }

        /// <summary>
        /// Gets or sets the place.
        /// </summary>
        /// <value>The place.</value>
        public Place Place { get; set; }

        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        /// <value>The department.</value>
        public Department Department { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer.
        /// </summary>
        /// <value>The manufacturer.</value>
        public Manufacturer Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the inventory.
        /// </summary>
        /// <value>The inventory.</value>
        public Inventory Inventory { get; set; }

        /// <summary>
        /// Gets or sets the last update.
        /// </summary>
        /// <value>The last update.</value>
        [DataType(DataType.DateTime)]
        public DateTime LastUpdate { get; set; }
    }
}
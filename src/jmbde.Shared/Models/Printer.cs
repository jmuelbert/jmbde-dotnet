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
    /// Paper size.
    /// </summary>
    public enum PaperSize { A0, A1, A2, A3, A4, A5, LTR, LGL }

    /// <summary>
    /// Printer.
    /// </summary>
    public partial class Printer
    {
        /// <summary>
        /// Gets or sets the printer identifier.
        /// </summary>
        /// <value>The printer identifier.</value>
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
        /// Gets or sets the serial number.
        /// </summary>
        /// <value>The serial number.</value>
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
                      MinimumLength = 5)]
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the service tag.
        /// </summary>
        /// <value>The service tag.</value>
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
                      MinimumLength = 5)]
        public string ServiceTag { get; set; }

        /// <summary>
        /// Gets or sets the service number.
        /// </summary>
        /// <value>The service number.</value>
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
                      MinimumLength = 5)]
        public string ServiceNumber { get; set; }

        /// <summary>
        /// Gets or sets the network.
        /// </summary>
        /// <value>The network.</value>
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
                      MinimumLength = 5)]
        public string Network { get; set; }

        /// <summary>
        /// Gets or sets the network ip address.
        /// </summary>
        /// <value>The network ip address.</value>
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
                      MinimumLength = 5)]
        public string NetworkIpAddress { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see
        /// cref="T:JMuelbert.BDE.Data.Models.Printer"/> is active.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see
        /// cref="T:JMuelbert.BDE.Data.Models.Printer"/> is replace.
        /// </summary>
        /// <value><c>true</c> if replace; otherwise, <c>false</c>.</value>
        public bool Replace { get; set; }

        /// <summary>
        /// Gets or sets the resources.
        /// </summary>
        /// <value>The resources.</value>
        public string Resources { get; set; }

        /// <summary>
        /// Gets or sets the size of the paper.
        /// </summary>
        /// <value>The size of the paper.</value>
        public PaperSize? PaperSize { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see
        /// cref="T:JMuelbert.BDE.Data.Models.Printer"/> is color.
        /// </summary>
        /// <value><c>true</c> if color; otherwise, <c>false</c>.</value>
        public bool Color { get; set; }

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
        public Employee Employee { get; set; }

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
        /// Gets or sets the computer.
        /// </summary>
        /// <value>The computer.</value>
        /// public Computer Computer { get; set; }

        /// <summary>
        /// Gets or sets the last update.
        /// </summary>
        /// <value>The last update.</value>
        [DataType(DataType.DateTime)]
        public DateTime LastUpdate { get; set; }
    }
}
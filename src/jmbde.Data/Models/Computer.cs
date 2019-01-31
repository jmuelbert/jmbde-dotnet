/**************************************************************************
 **
 ** Copyright (c) 2016-2018 Jürgen Mülbert. All rights reserved.
 **
 ** This file is part of jmbde
 **
 ** Licensed under the EUPL, Version 1.2 or – as soon they
 ** will be approved by the European Commission - subsequent
 ** versions of the EUPL (the "Licence");
 ** You may not use this work except in compliance with the
 ** Licence.
 ** You may obtain a copy of the Licence at:
 **
 ** https://joinup.ec.europa.eu/page/eupl-text-11-12
 **
 ** Unless required by applicable law or agreed to in
 ** writing, software distributed under the Licence is
 ** distributed on an "AS IS" basis,
 ** WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 ** express or implied.
 ** See the Licence for the specific language governing
 ** permissions and limitations under the Licence.
 **
 ** Lizenziert unter der EUPL, Version 1.2 oder - sobald
 **  diese von der Europäischen Kommission genehmigt wurden -
 ** Folgeversionen der EUPL ("Lizenz");
 ** Sie dürfen dieses Werk ausschließlich gemäß
 ** dieser Lizenz nutzen.
 ** Eine Kopie der Lizenz finden Sie hier:
 **
 ** https://joinup.ec.europa.eu/page/eupl-text-11-12
 **
 ** Sofern nicht durch anwendbare Rechtsvorschriften
 ** gefordert oder in schriftlicher Form vereinbart, wird
 ** die unter der Lizenz verbreitete Software "so wie sie
 ** ist", OHNE JEGLICHE GEWÄHRLEISTUNG ODER BEDINGUNGEN -
 ** ausdrücklich oder stillschweigend - verbreitet.
 ** Die sprachspezifischen Genehmigungen und Beschränkungen
 ** unter der Lizenz sind dem Lizenztext zu entnehmen.
 **
 **************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// TODO: Software cannot be in many Computers

namespace JMuelbert.BDE.Data.Models
{
    /// <summary>
    /// Computer.
    /// </summary>
    public partial class Computer {
        /// <summary>
        /// Gets or sets the computer identifier.
        /// </summary>
        /// <value>The computer identifier.</value>
        public long ComputerId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Required]
        [StringLength (50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the serial number.
        /// </summary>
        /// <value>The serial number.</value>
        [StringLength (20, ErrorMessage = "Serialnumber cannot be longer than 20 characters.")]
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the service tag.
        /// </summary>
        /// <value>The service tag.</value>
        [StringLength (20, ErrorMessage = "Service Tag cannot be longer than 20 characters.")]
        public string ServiceTag { get; set; }

        /// <summary>
        /// Gets or sets the service number.
        /// </summary>
        /// <value>The service number.</value>
        [StringLength (20, ErrorMessage = "Service Number cannot be longer than 20 characters.")]
        public string ServiceNumber { get; set; }

        /// <summary>
        /// Gets or sets the memory.
        /// </summary>
        /// <value>The memory.</value>
        public long? Memory { get; set; }

        /// <summary>
        /// Gets or sets the network.
        /// </summary>
        /// <value>The network.</value>
        [StringLength (50, ErrorMessage = "Network cannot be longer than 50 characters.")]
        public string Network { get; set; }

        /// <summary>
        /// Gets or sets the network ip address.
        /// </summary>
        /// <value>The network ip address.</value>
        [StringLength (50, ErrorMessage = "IP-Address cannot be longer than 50 characters.")]
        public string NetworkIpAddress { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:JMuelbert.BDE.Data.Models.Computer"/> is active.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        public bool Active { get; set; }

        /// <summary>
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
        /// Gets or sets the processor.
        /// </summary>
        /// <value>The processor.</value>
        public Processor Processor { get; set; }

        /// <summary>
        /// Gets or sets the os.
        /// </summary>
        /// <value>The os.</value>
        public Software OS { get; set; }

        /// <summary>
        /// Gets or sets the software.
        /// </summary>
        /// <value>The software.</value>
        public ICollection<Software> Software { get; set; }
        /// <summary>
        /// Gets or sets the printer.
        /// </summary>
        /// <value>The printer.</value>
        /// public Printer Printer { get; set; }

        /// <summary>
        /// Gets or sets the last update.
        /// </summary>
        /// <value>The last update.</value>
        [DataType (DataType.DateTime)]
        public DateTime LastUpdate { get; set; }
    }
}

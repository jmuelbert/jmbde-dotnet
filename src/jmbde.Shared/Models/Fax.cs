/**************************************************************************
 **
 ** Copyright (c) 2016-2020 Jürgen Mülbert. All rights reserved.
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

namespace JMuelbert.BDE.Shared.Models
{
	/// <summary>
	/// Fax.
	/// </summary>
	public partial class Fax
	{

		/// <summary>
		/// Gets or sets the fax identifier.
		/// </summary>
		/// <value>The fax identifier.</value>
		public int ID { get; set; }

		/// <summary>
		/// Gets or sets the number.
		/// </summary>
		/// <value>The number.</value>
		[Required]
		[StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
		[DataType(DataType.PhoneNumber)]
		public string Number { get; set; }

		/// <summary>
		/// Gets or sets the serial number.
		/// </summary>
		/// <value>The serial number.</value>
		[StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
		public string SerialNumber { get; set; }

		/// <summary>
		/// Gets or sets the pin.
		/// </summary>
		/// <value>The pin.</value>
		[StringLength(10, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
		public string Pin { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="T:JMuelbert.BDE.Data.Models.Fax"/> is active.
		/// </summary>
		/// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
		public bool Active { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="T:JMuelbert.BDE.Data.Models.Fax"/> is replace.
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
		public ICollection<Employee> Employee { get; set; }

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

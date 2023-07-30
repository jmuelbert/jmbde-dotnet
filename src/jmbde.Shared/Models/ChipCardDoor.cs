/**************************************************************************
 **
 ** SPDX-FileCopyrightText: © 2016-2023 Jürgen Mülbert
 **
 ** SPDX-License-Identifier: EUPL-1.2
 **
 *************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JMuelbert.BDE.Shared.Models
{
	/// <summary>
	/// Chip card door.
	/// </summary>
	public partial class ChipCardDoor
	{
		/// <summary>
		/// Gets or sets the chip card door identifier.
		/// </summary>
		/// <value>The chip card door identifier.</value>
		public int ID { get; set; }

		/// <summary>
		/// Gets or sets the number.
		/// </summary>
		/// <value>The number.</value>
		[Required]
		[StringLength(25, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
					  MinimumLength = 5)]

		/// <summary>
		/// Gets or sets the number.
		/// </summary>
		/// <value>The place.</value>
		public string Number { get; set; }

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
		/// Gets or sets the employee.
		/// </summary>
		/// <value>The employee.</value>
		public ICollection<Employee> Employee { get; set; }

		/// <summary>
		/// Gets or sets the last update.
		/// </summary>
		/// <value>The last update.</value>
		[DataType(DataType.DateTime)]
		public DateTime LastUpdate { get; set; }
	}
}
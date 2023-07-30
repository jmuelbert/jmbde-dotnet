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
	/// Chip card.
	/// </summary>
	public partial class ChipCard
	{
		/// <summary>
		/// Gets or sets the chip card identifier.
		/// </summary>
		/// <value>The chip card identifier.</value>
		public int ID { get; set; }

		/// <summary>
		/// Gets or sets the number.
		/// </summary>
		/// <value>The number.</value>
		[Required]
		[StringLength(25, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
					  MinimumLength = 5)]
		public string Number { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see
		/// cref="T:JMuelbert.BDE.Data.Models.ChipCard"/> is locked.
		/// </summary>
		/// <value><c>true</c> if locked; otherwise, <c>false</c>.</value>
		public bool Locked { get; set; }

		/// <summary>
		/// Gets or sets the chip card door.
		/// </summary>
		/// <value>The chip card door.</value>
		public ICollection<ChipCardDoor> ChipCardDoor { get; set; }

		/// <summary>
		/// Gets or sets the chip card profile.
		/// </summary>
		/// <value>The chip card profile.</value>
		public ICollection<ChipCardProfile> ChipCardProfile { get; set; }

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
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
	/// System data.
	/// </summary>
	public partial class SystemData
	{
		/// <summary>
		/// Gets or sets the system data identifier.
		/// </summary>
		/// <value>The system data identifier.</value>
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
		/// Gets or sets a value indicating whether this <see
		/// cref="T:JMuelbert.BDE.Data.Models.SystemData"/> is local.
		/// </summary>
		/// <value><c>true</c> if local; otherwise, <c>false</c>.</value>
		public bool Local { get; set; }

		/// <summary>
		/// Gets or sets the company.
		/// </summary>
		/// <value>The company.</value>
		public Company Company { get; set; }

		/// <summary>
		/// Gets or sets the last update.
		/// </summary>
		/// <value>The last update.</value>
		[DataType(DataType.DateTime)]
		public DateTime LastUpdate { get; set; }
	}
}
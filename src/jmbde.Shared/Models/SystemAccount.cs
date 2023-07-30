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
	/// System account.
	/// </summary>
	public partial class SystemAccount
	{
		/// <summary>
		/// Gets or sets the system account identifier.
		/// </summary>
		/// <value>The system account identifier.</value>
		public int ID { get; set; }

		/// <summary>
		/// Gets or sets the name of the user.
		/// </summary>
		/// <value>The name of the user.</value>
		[Required]
		[StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
					  MinimumLength = 5)]
		public string UserName { get; set; }

		/// <summary>
		/// Gets or sets the pass word.
		/// </summary>
		/// <value>The pass word.</value>
		[Required]
		[StringLength(25, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
					  MinimumLength = 5)]
		[DataType(DataType.Password)]
		public string PassWord { get; set; }

		/// <summary>
		/// Gets or sets the system data.
		/// </summary>
		/// <value>The system data.</value>
		public SystemData SystemData { get; set; }

		/// <summary>
		/// Gets or sets the last update.
		/// </summary>
		/// <value>The last update.</value>
		[DataType(DataType.DateTime)]
		public DateTime LastUpdate { get; set; }
	}
}

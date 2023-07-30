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
	/// Manufacturer.
	/// </summary>
	public partial class Manufacturer
	{
		/// <summary>
		/// Gets or sets the manufacturer identifier.
		/// </summary>
		/// <value>The manufacturer identifier.</value>
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
		/// Gets or sets the name2.
		/// </summary>
		/// <value>The name2.</value>
		[StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
					  MinimumLength = 5)]
		public string Name2 { get; set; }

		/// <summary>
		/// Gets or sets the supporter.
		/// </summary>
		/// <value>The supporter.</value>
		[StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
					  MinimumLength = 5)]
		public string Supporter { get; set; }

		/// <summary>
		/// Gets or sets the street.
		/// </summary>
		/// <value>The street.</value>
		[StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
					  MinimumLength = 5)]
		public string Street { get; set; }

		/// <summary>
		/// Gets or sets the street22.
		/// </summary>
		/// <value>The street22.</value>
		[StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
					  MinimumLength = 5)]
		public string Street22 { get; set; }

		/// <summary>
		/// Gets or sets the zip code.
		/// </summary>
		/// <value>The zip code.</value>
		public ZipCode ZipCode { get; set; }

		/// <summary>
		/// Gets or sets the mail address.
		/// </summary>
		/// <value>The mail address.</value>
		[StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
					  MinimumLength = 5)]
		[DataType(DataType.EmailAddress)]
		public string MailAddress { get; set; }

		/// <summary>
		/// Gets or sets the phone number.
		/// </summary>
		/// <value>The phone number.</value>
		[StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
					  MinimumLength = 5)]
		[DataType(DataType.PhoneNumber)]
		public string PhoneNumber { get; set; }

		/// <summary>
		/// Gets or sets the fax number.
		/// </summary>
		/// <value>The fax number.</value>
		[StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
					  MinimumLength = 5)]
		[DataType(DataType.PhoneNumber)]
		public string FaxNumber { get; set; }

		/// <summary>
		/// Gets or sets the hotline number.
		/// </summary>
		/// <value>The hotline number.</value>
		[StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
					  MinimumLength = 5)]
		[DataType(DataType.PhoneNumber)]
		public string HotlineNumber { get; set; }

		/// <summary>
		/// Gets or sets the last update.
		/// </summary>
		/// <value>The last update.</value>
		[DataType(DataType.DateTime)]
		public DateTime LastUpdate { get; set; }
	}
}
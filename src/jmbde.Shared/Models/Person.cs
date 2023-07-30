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

// TODO: Change the use of SystemAccount

namespace JMuelbert.BDE.Shared.Models
{
	/// <summary>
	/// Gender.
	/// </summary>
	public enum Gender { F, M, D }

	/// <summary>
	/// Person.
	/// </summary>
	public partial class Person
	{
		/// <summary>
		/// Gets or sets the Person identifier.
		/// </summary>
		/// <value>The Person identifier.</value>
		public int PersonID { get; set; }

		/// <summary>
		/// Gets or sets the Person ident.
		/// </summary>
		/// <value>The Person ident.</value>
		[StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
					  MinimumLength = 5)]
		public string PersonIdent { get; set; }

		/// <summary>
		/// Gets or sets the gender.
		/// </summary>
		/// <value>The gender.</value>
		public Gender Gender { get; set; }

		/// <summary>
		/// Gets or sets the first name.
		/// </summary>
		/// <value>The first name.</value>
		[Display(Name = "First Name")]
		[StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
					  MinimumLength = 5)]
		public string FirstName { get; set; }

		/// <summary>
		/// Gets or sets the last name.
		/// </summary>
		/// <value>The last name.</value>
		[Display(Name = "Last Name")]
		[Required]
		[StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
					  MinimumLength = 5)]
		public string LastName { get; set; }

		/// <summary>
		/// Gets or sets the birth day.
		/// </summary>
		/// <value>The birth day.</value>
		[DataType(DataType.Date)]
		public DateTime BirthDay { get; set; }

		/// <summary>
		/// Gets or sets the street.
		/// </summary>
		/// <value>The street.</value>
		[Required]
		[StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
					  MinimumLength = 5)]
		public string Street { get; set; }

		/// <summary>
		/// Gets or sets the zip code.
		/// </summary>
		/// <value>The zip code.</value>
		public ZipCode ZipCode { get; set; }

		/// <summary>
		/// Gets or sets the home phone.
		/// </summary>
		/// <value>The home phone.</value>
		[StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
					  MinimumLength = 5)]
		[DataType(DataType.PhoneNumber)]
		public string HomePhone { get; set; }

		/// <summary>
		/// Gets or sets the home mobile.
		/// </summary>
		/// <value>The home mobile.</value>
		[StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
					  MinimumLength = 5)]
		[DataType(DataType.PhoneNumber)]
		public string HomeMobile { get; set; }

		/// <summary>
		/// Gets or sets the home mail address.
		/// </summary>
		/// <value>The home mail address.</value>
		[StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
					  MinimumLength = 5)]
		[DataType(DataType.EmailAddress)]
		public string HomeMailAddress { get; set; }

		/// <summary>
		/// Gets or sets the photo.
		/// </summary>
		/// <value>The photo.</value>
		public byte[] Photo { get; set; }
	}
}
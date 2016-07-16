/*
 * Copyright 2016 Jürgen Mülbert
 *
 * Licensed under the EUPL, Version 1.1 or – as soon they
   will be approved by the European Commission - subsequent
   versions of the EUPL (the "Licence");
 * You may not use this work except in compliance with the Licence.
 * You may obtain a copy of the Licence at:
 *
 * https://joinup.ec.europa.eu/software/page/eupl5
 *
 * Unless required by applicable law or agreed to in
   writing, software distributed under the Licence is
   distributed on an "AS IS" basis,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
   express or implied.
 * See the Licence for the specific language governing
  permissions and limitations under the Licence.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jmbde.Models
{
    /// <summary>
    /// The Class for the Company
    /// </summary>
    public partial class Company
    {
        /// <summary>
        /// The constructor is empty
        /// may be need them later
        /// </summary>
        // public Company()  { }

        /// <summary>
        /// The CompanyId
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The Name
        /// This is <em>Required</em>
        /// </summary>
        [Required, StringLength(50), Display(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// The Name2
        /// </summary>
        [StringLength(50), Display(Name = "Name2")]
        public string Name2 { get; set; }

        /// <summary>
        /// The Zipcode of the City
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// The City
        /// </summary>
        [Display(Name = "City")]
        public string City { get; set; }

        /// <summary>
        /// The Street
        /// </summary>
        [Display(Name = "Street")]
        public string Street { get; set; }

        /// <summary>
        /// The PhoneNumber
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The MobileNumber
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        /// The FaxNumber (private)
        /// </summary>
        public string FaxNumber { get; set; }

        /// <summary>
        /// The Mail Address
        /// </summary>
        [StringLength(50), Display(Name = "E-Mail")]
        public string Mail { get; set; }

        /// <summary>
        /// Is this Company active ?
        /// </summary>
        public bool? Active { get; set; }

        /// <summary>
        /// The foreign key for the employee
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// The Connection to the Employee
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// The Date and Time of last touch this DataSet
        /// </summary>
        public DateTime? LastUpdate { get; set; }
    }
}
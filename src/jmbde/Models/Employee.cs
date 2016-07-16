﻿/*
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
    /// The Class for the Employee
    /// </summary>
    public partial class Employee
    {
        /// <summary>
        /// The constructor is empty
        /// may be need them later
        /// </summary>
        /// public Employee()  { }

        /// <summary>
        /// The EmployeeID
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The Firstname
        /// </summary>
        [StringLength(20), Display(Name = "Firstname")]
        public string FirstName { get; set; }

        /// <summary>
        /// The Middlename
        /// This is for future improvments
        /// actual dont need dont use
        /// </summary>
        [StringLength(20), Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        /// <summary>
        /// The Name
        /// This is <em>Required</em>
        /// </summary>
        [Required, StringLength(30), Display(Name = "Last Name")]
        public string Name { get; set; }

        /// <summary>
        /// The Gender
        /// </summary>
        [StringLength(1), Display(Name = "Gender")]
        public string Gender { get; set; }

        /// <summary>
        /// The Zipcode of the City (private)
        /// </summary>
        [StringLength(10), Display(Name = "Zipcode")]
        public string ZipCode { get; set; }

        /// <summary>
        /// The City
        /// </summary>
        [StringLength(50), Display(Name = "City")]
        public string City { get; set; }

        /// <summary>
        /// The Street
        /// </summary>
        [StringLength(50), Display(Name = "Street")]
        public string Street { get; set; }

        /// <summary>
        /// The PhoneNumber (private)
        /// </summary>
        [StringLength(20), Display(Name = "Phonenumber")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The MobileNumber (private)
        /// </summary>
        [StringLength(20), Display(Name = "Mobilenumber")]
        public string MobileNumber { get; set; }

        /// <summary>
        /// The FaxNumber (private)
        /// </summary>
        [StringLength(20), Display(Name = "Faxnumber")]
        public string FaxNumber { get; set; }

        /// <summary>
        /// The Mail Address
        /// </summary>
        [StringLength(40), Display(Name = "E-Mail")]
        public string Mail { get; set; }

        /// <summary>
        /// The Birthday
        /// </summary>
        public DateTime? Birthday { get; set; }

        //// <summary>
        /// A Photo of the Employee
        /// </summary>
        public byte[] Photo { get; set; }

        // --------------------------------------
        // Business Data
        // --------------------------------------

        /// <summary>
        /// EmployeNO
        /// The Number or ID in the Company
        /// </summary>
        [Required, Display(Name = "Employee ID")]
        public string EmployeeNO
        {
            get; set;
        }
        /// <summary>
        /// The Business Mail Address
        /// </summary>
        public string BusinessMail { get; set; }

        /// <summary>
        /// The DataCare
        /// The Employee must agree
        /// </summary>
        public bool? DataCare { get; set; }

        /// <summary>
        /// Is this Employee active ?
        /// </summary>
        public bool? Active { get; set; }

        /// <summary>
        /// The StartDate
        /// from this date work the employee for the company
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// The EndDate
        /// from this date work the employee for the company
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// For the Company_Id work this Employee
        /// </summary>
        public int? CompanyId { get; set; }

        /// <summary>
        /// In this Department work this employee
        /// </summary>
        public int? DepartmentId { get; set; }

        /// <summary>
        /// This work should the employee do
        /// </summary>
        public int? WorkfunctionId { get; set; }

        /// <summary>
        /// This is the Workingplace for the employee
        /// </summary>
        public int? PlaceId { get; set; }

        /// <summary>
        /// The ChipCard (Transponder) to access the areas
        /// </summary>
        [StringLength(20), Display(Name = "Chip Card")]
        public string ChipCard { get; set; }

        /// <summary>
        /// The Notes
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// The Date and Time of last touch this DataSet
        /// </summary>
        public DateTime? LastUpdate { get; set; }
    }
}

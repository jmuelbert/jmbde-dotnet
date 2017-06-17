/*
 * Copyright 2016, 2017 Jürgen Mülbert
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
using System.ComponentModel.DataAnnotations.Schema;

namespace jmbde.Models
{
    public enum Gender 
    {
        O, F, M
    }

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
        public int ID { get; set; }
        public string Nr { get; set; }

        /// <summary>
        /// The Gender
        /// </summary>
        public string Gender { get; set; }

        public int TitleID { get; set; }

        /// <summary>
        /// The Firstname
        /// </summary>
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters.")]
        public string Firstname { get; set; }

        /// <summary>
        /// The Middlename
        /// This is for future improvments
        /// actual dont need dont use
        /// </summary>
        [StringLength(20), Display(Name = "Middle Name")]
        public string Middlename { get; set; }

        /// <summary>
        /// The Name
        /// This is <em>Required</em>
        /// </summary>
        [Required]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters.")]
        public string Lastname { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [StringLength(50, ErrorMessage = "Address cannot be longer than 50 characters.")]
        public string Address { get; set; }
        public int CityID { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Homephone { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Homemobile { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Homeemail { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Businessemail { get; set; }
        public bool Datacare { get; set; }
        public bool Active { get; set; }
        public byte[] Photo { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Startdate { get; set; }

        [DataType(DataType.Date)]
        public DateTime Enddate { get; set; }

        public int CompanyID { get; set; }
        public int PhoneID { get; set; }
        public int MobileID { get; set; }
        public int FaxID { get; set; }
        public int ChipcardID { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Timestamp { get; set; }

        // Navigation Properties
        // public virtual Title Title { get; set; }
        // 
        
        // public virtual City City { get; set; }
        // public virtual Phone Phone { get; set; }
        // public virtual Mobile Mobile { get; set; }
        // public virtual Fax Fax { get; set; }
        // public virtual Chipcard Chipcard { get; set; }

        public virtual ICollection<Department> Department { get; set; }     
        public virtual ICollection<Function> Function { get; set; }
        public virtual ICollection<Device> Device { get; set; }
        public virtual ICollection<Printer> Printer { get; set; }

        public virtual ICollection<Account> Account { get; set; }
        public virtual ICollection<Document> Document { get; set; }


        public string FullName {
            get { return Lastname + ", " + Firstname; }
        }

    }
}

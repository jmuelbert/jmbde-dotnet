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
    /// The Class for the Mobile
    /// </summary>
    public partial class Mobile
    {
        /// <summary>
        /// The constructor is empty
        /// may be need them later
        /// </summary>
        /// public Mobile()  { }

        /// <summary>
        /// The MobileId
        /// </summary>
        [Key]
        public int Id { get; set; }


        /// <summary>
        /// The Number of the Mobile
        /// </summary>
        [Required, StringLength(30), Display(Name = "Mobile Number")]
        public string Number { get; set; }

        /// <summary>
        /// Is this Phone active ?
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
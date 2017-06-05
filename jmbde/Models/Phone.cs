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

namespace jmbde.Models
{
    /// <summary>
    /// The Class for the Phone
    /// </summary>
    public partial class Phone
    {
        /// <summary>
        /// The constructor is empty
        /// may be need them later
        /// </summary>
        /// public Phone()  { }

        /// <summary>
        /// The PhoneID
        /// </summary>
        public int ID { get; set; }
        public int DevicenameID { get; set; }
        public int DevicetypeID { get; set; }
        public string Serialnumber { get; set; }

        /// <summary>
        /// The Number of the Phone
        /// </summary>
        [Required, StringLength(30), Display(Name = "Phone Number")]
        public string Number { get; set; }
        public string Pin { get; set; }
        
        /// <summary>
        /// Is this Phone active ?
        /// </summary>
        public bool Active { get; set; }
        public bool Replace { get; set; }

       
        /// <summary>
        /// The foreign key for the employee
        /// </summary>
        public int EmployeeID { get; set; }
        public int PlaceID { get; set; }
        public int DepartmentID { get; set; }
        public int ManufacturerID { get; set; }
        public int InventoryID { get; set; }

        
        /// <summary>
        /// The Date and Time of last touch this DataSet
        /// </summary>
        [DataType(DataType.DateTime)]
        public string Timestamp { get; set; }


       /// <summary>
        /// The Connection to the Employee
        /// </summary>
        public virtual Devicename Devicename { get; set; }
        public virtual Devicetype Devicetype { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Place Place { get; set; }
        public virtual Department Department { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Inventory Inventory { get; set; }
    }
}

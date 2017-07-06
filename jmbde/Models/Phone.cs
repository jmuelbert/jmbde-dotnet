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
  
         /// <summary>
        /// The Number of the Phone
        /// </summary>
        [Required, StringLength(30), Display(Name = "Phone Number")]
        public string number { get; set; }
 
        public string pin { get; set; }
        public string serialNumber { get; set; }

        
        /// <summary>
        /// Is this Phone active ?
        /// </summary>
        public bool active { get; set; }
        public bool replace { get; set; }

       
        /// <summary>
        /// The foreign key for the employee
        /// </summary>
        public int EmployeeID { get; set; }

        public int DevicenameID { get; set; }
        public int DevicetypeID { get; set; }
        public int PlaceID { get; set; }
        public int DepartmentID { get; set; }
        public int CompanyID { get; set; }
        public int InventoryID { get; set; }

        
        /// <summary>
        /// The Date and Time of last touch this DataSet
        /// </summary>
      
        [DataType(DataType.DateTime)]
        public DateTime created { get; set; }        

        [DataType(DataType.DateTime)]
        public DateTime timeStamp { get; set; }
}


       /// <summary>
        /// The Connection to the Employee
        /// </summary>
    }
}

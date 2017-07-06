/*
 * Copyright 2016,2017 Jürgen Mülbert
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
    /// <summary>
    /// The Class for the Devices
    /// </summary>
    public partial class Device
    {
        /// <summary>
        /// The constructor is empty
        /// may be need them later
        /// </summary>
        // public Device()  { }

        /// <summary>
        /// The ComputerId
        /// </summary>
        [Key]
        public int ID { get; set; }
      
        public string serialNumber { get; set; }
        public string serviceTag { get; set; }
        public string serviceNumber { get; set; }
        public int memory { get; set; }
        public string netWork { get; set; }
        public string netWorkName { get; set; }

        /// <summary>
        /// Is this Computer active ?
        /// </summary>
        public bool active { get; set; }
        public bool replace { get; set; }

        public int EmployeeID { get; set; }
        public int CompanyID { get; set; }
        public int DevicetypeID { get; set; }
        public int DevicenameID { get; set; }

        public int PlaceID { get; set; }
        public int InventoryID { get; set; }
        public int ProcessorID { get; set; }
        public int OsID { get; set; }

        /// <summary>
        /// The Date and Time of last touch this DataSet
        /// </summary>
       
        [DataType(DataType.DateTime)]
        public DateTime created { get; set; }        

        [DataType(DataType.DateTime)]
        public DateTime timeStamp { get; set; }



        // Navigation Properties
        // public virtual Employee Employee { get; set; }
        // public virtual Company Company { get; set; }
        // public virtual Devicetype Devicetype { get; set; }
        // public virtual Devicename Devicename { get; set; }
        // public virtual Place Place { get; set; }
        // public virtual Inventory Inventory { get; set; }
        // public virtual Processor Processor { get; set; }
        // public virtual Os Os { get; set; }
        // public virtual ICollection<Software> Software { get; set; }
    }
}

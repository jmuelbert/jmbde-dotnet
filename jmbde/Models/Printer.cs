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
        /// The Class for the Printer
        /// </summary>

    public partial class Printer
    {
        /// <summary>
        /// The constructor is empty
        /// may be need them later
        /// </summary>
        /// public Printer()  { }

        /// <summary>
        /// The PrinterID
        /// </summary>
        [Key]
        public int ID { get; set; }
        public int DevicenameID { get; set; }
        public int DevicetypeID { get; set; }
        public string Serialnumber { get; set; }
        public string Network { get; set; }
        public string NetworkName { get; set; }
        public string NetworkIpaddress { get; set; }
        public bool Active { get; set; }
        public bool Replace { get; set; }
        public string Resources { get; set; }
        public string PapersizeMax { get; set; }
        public bool Color { get; set; }

        public int EmployeeID { get; set; }
        public int PlaceID { get; set; }
        public int DepartmentID { get; set; }
        public int ManufacturerID { get; set; }
        public int InventoryID { get; set; }

        [DataType(DataType.DateTime)]
        public string Timestamp { get; set; }

        // Navigation Properties
        public virtual Employee Employee { get; set; }
        public virtual Devicename Devicename { get; set; }
        public virtual Devicetype Devicetype { get; set; }
        public virtual Place Place { get; set; }
        public virtual Department Department { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Inventory Inventory { get; set; }


        public virtual ICollection<Computer> Computer { get; set; }
    }
}

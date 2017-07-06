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

        public string serialnumber { get; set; }
        public string netWork { get; set; }
        public string netWorkName { get; set; }
        public bool active { get; set; }
        public bool replace { get; set; }
        public string resources { get; set; }
        public string paperSizeMax { get; set; }
        public bool color { get; set; }
        public bool copier { get; set; }
        public bool fax { get; set; }

        public int EmployeeID { get; set; }

        public int DevicenameID { get; set; }
        public int DevicetypeID { get; set; }
        public int PlaceID { get; set; }
        public int DepartmentID { get; set; }
        public int CompanyID { get; set; }
        public int InventoryID { get; set; }

      
        [DataType(DataType.DateTime)]
        public DateTime created { get; set; }        

        [DataType(DataType.DateTime)]
        public DateTime timeStamp { get; set; }


        // Navigation Properties


        public virtual ICollection<Device> Device { get; set; }
    }
}

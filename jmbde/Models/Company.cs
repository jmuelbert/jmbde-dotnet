/*
 * Copyright 2017 Jürgen Mülbert
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
    public partial class Company
    {
        public int ID { get; set; }
        public int TitleID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string name { get; set; }
        public string name2 { get; set; }
        public string address { get; set; }
        public string address2 { get; set; }
        public int CityID { get; set; }
        public string eMail { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }

      
        [DataType(DataType.DateTime)]
        public DateTime created { get; set; }        

        [DataType(DataType.DateTime)]
        public DateTime timeStamp { get; set; }


        // Navigation Properties

        // public virtual ICollection<Employee> Employees { get; set; }
        // public virtual ICollection<Device> Devices { get; set; }
        // public virtual ICollection<Fax> Faxes { get; set; }
        // public virtual ICollection<Mobile> Mobiles { get; set; }
        // public virtual ICollection<Phone> Phones { get; set; }
        // public virtual ICollection<Printer> Printers { get; set; }
    }
}
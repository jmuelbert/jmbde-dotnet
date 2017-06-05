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
  ///  #warningdotnet 
  ///  The child/dependent side could not be determined for the one-to-one relationship that was detected between 'Systemdata.Accout' and 'A
  /// ccount.Systemdata'. To identify the child/dependent side of the relationship, configure the foreign key property. See http://go.micro
  /// soft.com/fwlink/?LinkId=724062 for more details.
  /// 
    public partial class Systemdata
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Local { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public int CityID { get; set; }
        // public int AccountId { get; set; }

        [DataType(DataType.DateTime)]
        public string Timestamp { get; set; }

        public virtual City City { get; set; }
        // public virtual Account Accout { get; set; }
    }
}

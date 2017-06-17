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
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public int CityID { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Timestamp { get; set; }
    }
}
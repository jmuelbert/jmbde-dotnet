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

namespace jmbde.Models
{
    /// <summary>
    /// The Class for the ChipCard
    /// </summary>

    public partial class Chipcard
    {
       /// <summary>
        /// The constructor is empty
        /// may be need them later
        /// </summary>
        // public chipcard()  { }

        /// <summary>
        /// The ChipcardId
        /// </summary>  
        public int ID { get; set; }

        public bool Active { get; set; }
        public string Number { get; set; }
        public int EmployeeID { get; set; }  
        
        [DataType(DataType.DateTime)]
        public string Timestamp { get; set; }

        // Navigation Properties
        // public virtual Employee Employee { get; set; }
        // http://go.microsoft.com/fwlink/?LinkId=724062

        public virtual ICollection<Chipcarddoor> Chipcarddoor { get; set; }
        public virtual ICollection<Chipcardprofile> Chipcardprofile { get; set; }

    }
}

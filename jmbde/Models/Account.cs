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
using System.ComponentModel.DataAnnotations.Schema;

namespace jmbde.Models
{

   /// <summary>
    /// The Class for the Account
    /// </summary>

    public partial class Account
    {
        /// <summary>
        /// The AccountID
        /// </summary>
        public int ID { get; set; }

       /// <summary>
        /// The UserName
        /// </summary>
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters.")]
        public string Username { get; set; }

        /// <summary>
        /// The Password
        /// </summary>
        [StringLength(30, ErrorMessage = "Password cannot be longer than 30 characters.")]
        public string Password { get; set; }

        public bool Active { get; set; }

        public int CompanyID { get; set; }  
        
        [DataType(DataType.DateTime)]
        public DateTime Timestamp { get; set; }

        // Navigation Properties

        public virtual Company Company { get; set; }


    }
}

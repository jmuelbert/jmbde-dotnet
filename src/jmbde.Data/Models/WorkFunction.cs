/**************************************************************************
 **
 ** Copyright (c) 2016-2019 Jürgen Mülbert. All rights reserved.
 **
 ** This file is part of jmbde
 **
 ** Licensed under the EUPL, Version 1.2 or – as soon they
 ** will be approved by the European Commission - subsequent
 ** versions of the EUPL (the "Licence");
 ** You may not use this work except in compliance with the
 ** Licence.
 ** You may obtain a copy of the Licence at:
 **
 ** https://joinup.ec.europa.eu/page/eupl-text-11-12
 **
 ** Unless required by applicable law or agreed to in
 ** writing, software distributed under the Licence is
 ** distributed on an "AS IS" basis,
 ** WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 ** express or implied.
 ** See the Licence for the specific language governing
 ** permissions and limitations under the Licence.
 **
 ** Lizenziert unter der EUPL, Version 1.2 oder - sobald
 **  diese von der Europäischen Kommission genehmigt wurden -
 ** Folgeversionen der EUPL ("Lizenz");
 ** Sie dürfen dieses Werk ausschließlich gemäß
 ** dieser Lizenz nutzen.
 ** Eine Kopie der Lizenz finden Sie hier:
 **
 ** https://joinup.ec.europa.eu/page/eupl-text-11-12
 **
 ** Sofern nicht durch anwendbare Rechtsvorschriften
 ** gefordert oder in schriftlicher Form vereinbart, wird
 ** die unter der Lizenz verbreitete Software "so wie sie
 ** ist", OHNE JEGLICHE GEWÄHRLEISTUNG ODER BEDINGUNGEN -
 ** ausdrücklich oder stillschweigend - verbreitet.
 ** Die sprachspezifischen Genehmigungen und Beschränkungen
 ** unter der Lizenz sind dem Lizenztext zu entnehmen.
 **
 **************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;

namespace JMuelbert.BDE.Data.Models {
    /// <summary>
    /// Function.
    /// </summary>
    public partial class WorkFunction {
        /// <summary>
        /// Gets or sets the workfunction identifier.
        /// </summary>
        /// <value>The workfunction identifier.</value>
        public long WorkFunctionId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Required]
        [StringLength (50, ErrorMessage = "WorkFunction cannot be longer than 50 characters.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        /// <value>The priority.</value>
        public long? Priority { get; set; }

        /// <summary>
        /// Gets or sets the last update.
        /// </summary>
        /// <value>The last update.</value>
        [DataType (DataType.DateTime)]
        public DateTime LastUpdate { get; set; }
    }
}

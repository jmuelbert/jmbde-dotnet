/**************************************************************************
**
** Copyright (c) 2016-2018 Jürgen Mülbert. All rights reserved.
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
using System.Collections.Generic;

namespace jmbde.Models

{
    public partial class Mobile
    {
        public long MobileId { get; set; }
        public long? DeviceNameId { get; set; }
        public string SerialNumber { get; set; }
        public string Number { get; set; }
        public string Pin { get; set; }
        public string CardNumber { get; set; }
        public string Active { get; set; }
        public string Replace { get; set; }
        public long? DeviceTypeId { get; set; }
        public long? EmployeeId { get; set; }
        public long? PlaceId { get; set; }
        public long? DepartmentId { get; set; }
        public long? ManufacturerId { get; set; }
        public long? InventoryId { get; set; }
        public string LastUpdate { get; set; }
    }
}

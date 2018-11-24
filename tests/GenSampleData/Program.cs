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
using Microsoft.EntityFrameworkCore;

using GenSampleData.DataTables;


namespace GenSampleData
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = 1000;
            var computerCount = (count/10)*7;
            
            ChipCardData ccd = new ChipCardData();
            ccd.genData((count/10)*8);

            ChipCardDoorData ccdd = new ChipCardDoorData();
            ccdd.genData((count/10)*3);

            ChipCardProfileData ccdp = new ChipCardProfileData();
            ccdp.genData((count/30)*3);

            CityNameData cnd = new CityNameData();
            cnd.genData((count/40)*3);

            CompanyData cd = new CompanyData();
            cd.genData((count/50)*5);

            ComputerData comData = new ComputerData();
            comData.genData(computerCount);

            DepartmentData depData = new DepartmentData();
            depData.genData((count/50)*3);

            DeviceNameData devNameData  = new DeviceNameData();
            devNameData.genData((count/50)*2);

            DeviceTypeData devTypeData = new DeviceTypeData();
            devTypeData.genData((count/60)*2);

            DocumentData docData = new DocumentData();
            docData.genData(count);

            EmployeeData empData = new EmployeeData();
            empData.genData(count);

            FaxData faxData = new FaxData();
            faxData.genData((count/70)*3);

            FunctionData funcData = new FunctionData();
            funcData.genData((count/80)*2);
            
            InventoryData invData = new InventoryData();
            invData.genData(count);

            JobTitleData jobTData = new JobTitleData();
            jobTData.genData((count/80)*2);

            ManufacturerData manfactData = new ManufacturerData();
            manfactData.genData((count/50)*3);

            MobileData mobData = new MobileData();
            mobData.genData(count);

            PhoneData phoneData = new PhoneData();
            phoneData.genData(computerCount);

            PlaceData placeData = new PlaceData();
            placeData.genData((count/30)*5);

            PrinterData printData = new PrinterData();
            printData.genData((count/60)*5);

            ProcessorData procData = new ProcessorData();
            procData.genData(computerCount);

            SoftwareData softData = new SoftwareData();
            softData.genData((count/70)*10);

            SystemAccountData systemAccData = new SystemAccountData();
            systemAccData.genData(count);

            SystemDataData systemData = new SystemDataData();
            systemData.genData(count);

            ZipCodeData zipcodeData = new ZipCodeData();
            zipcodeData.genData((count/40)*3);


            Console.WriteLine("Finish!");
        }
    }
}

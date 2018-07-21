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
using GenFu;
using Microsoft.EntityFrameworkCore;
using jmbde.Models;

namespace GenSampleData.DataTables 
{
    public class EmployeeData {
        
        JMBDEContext context;

        public EmployeeData() {
            var optionsBuilder = new DbContextOptionsBuilder<JMBDEContext>();
            context = new JMBDEContext(optionsBuilder.UseSqlite("Data Source=jmbde.db").Options);

        }


        public void genData(int items) {
            var i = 1;

            A.Configure<Employee>()
                .Fill(c => c.EmployeeId, () => { return i++; })
                .Fill(c => c.EmployeeIdent, c =>  { return String.Format("EMP{0:0000}",i); })
                .Fill(c => c.Street).AsAddress()
                .Fill(c => c.BusinessMailAddress).AsEmailAddress()
                .Fill(e => e.HomeMailAddress).AsEmailAddress()
                .Fill(e => e.HomePhone).AsPhoneNumber()
                .Fill(e => e.HomeMobile).AsPhoneNumber()
                .Fill(e => e.Notes).AsLoremIpsumSentences();
               
            var employees = A.ListOf<Employee>(items);

            foreach (var item in employees)
            {
                Console.WriteLine($"{item.EmployeeIdent} {item.LastName} {item.LastUpdate}");
            }

            using (var ctx = context) {
                foreach (var item in employees)
                {
                    ctx.Employee.Add(item);
                    ctx.SaveChanges();
                }
            }

        }
    }
}
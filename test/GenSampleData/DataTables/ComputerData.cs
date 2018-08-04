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
    public class ComputerData {
        
        JMBDEContext context;

        public ComputerData() {
            var optionsBuilder = new DbContextOptionsBuilder<JMBDEContext>();
            context = new JMBDEContext(optionsBuilder.UseSqlite("Data Source=jmbde.db").Options);

        }


        public void genData(int items) {
            var i = 1;

            A.Configure<Computer>()
               .Fill(c => c.ComputerId, () => { return i; })
               .Fill(c => c.Name, c => { return String.Format("PC{0:00000}",i++ ); } )
               .Fill(c => c.SerialNumber, c => { return new Guid().ToString(); } )
               .Fill(c => c.ServiceTag, c => { return new Guid().ToString(); } )
               .Fill(c => c.ServiceNumber, c => { return new Guid().ToString(); } )
               .Fill(c => c.Memory, c => { return 4; } )
               .Fill(c => c.Active).WithRandom( new bool[] { true, true, false})
               .Fill(c => c.Replace).WithRandom( new bool[] { true, true, false});
              


            var computers = A.ListOf<Computer>(items);

            foreach (var item in computers)
            {
                Console.WriteLine($"{item.Name} {item.LastUpdate}");
            }

            using (var ctx = context) {
                foreach (var item in computers)
                {
                    ctx.Computer.Add(item);
                    ctx.SaveChanges();
                }
            }

        }
    }
}
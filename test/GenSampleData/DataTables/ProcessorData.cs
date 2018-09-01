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
using jmbdeData.Models;
using jmbde.Data;

namespace GenSampleData.DataTables 
{
    public class ProcessorData {
        

        private readonly jmbde.Data.JMBDEContext  _context;

        public ProcessorData() {
            var optionsBuilder = new DbContextOptionsBuilder<JMBDEContext>();
            _context = new JMBDEContext(optionsBuilder.UseSqlite("Data Source=app.db").Options);

        }


        public void genData(int items) {
            var i = 1;

            A.Configure<Processor>()
               .Fill(c => c.ProcessorId, () => { return i++; })
               .Fill(c => c.Name).WithRandom(new string[] {
                    "INTEL CORE I3",
                    "INTEL CORE I5",
                    "INTEL CORE I7",
                    "AMD FX8350",
                    "AMD RYZEN"
               })
               .Fill(c => c.ClockRate).WithRandom( new float[] {
                    3.2f,
                    3.8f,
                    4.2f,
                    4.8f
               })
               .Fill(c => c.Cores).WithinRange(1,8);
               
            var processors = A.ListOf<Processor>(items);

            foreach (var item in processors)
            {
                Console.WriteLine($"{item.Name} {item.LastUpdate}");
            }

            using (var ctx = _context) {
                foreach (var item in processors)
                {
                    ctx.Processor.Add(item);
                    ctx.SaveChanges();
                }
            }

        }
    }
}
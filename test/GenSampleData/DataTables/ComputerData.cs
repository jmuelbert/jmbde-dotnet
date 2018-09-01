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
using System.Globalization;
using GenFu;
using Microsoft.EntityFrameworkCore;
using jmbdeData.Models;
using jmbde.Data;

namespace GenSampleData.DataTables 
{
    public class ComputerData {
        
        private readonly jmbde.Data.JMBDEContext  _context;

        public ComputerData() {
            var optionsBuilder = new DbContextOptionsBuilder<JMBDEContext>();
            _context = new JMBDEContext(optionsBuilder.UseSqlite("Data Source=app.db").Options);

        }


        public void genData(int items) {
            var i = 1;

            A.Configure<Computer>()
               .Fill(c => c.ComputerId, () => { return i; })
               .Fill(c => c.Name, c => { return String.Format("PC{0:00000}",i++ ); } )
               .Fill(c => c.SerialNumber, c => { return  Guid.NewGuid().ToString(); } )
               .Fill(c => c.ServiceTag, c => { return Guid.NewGuid().ToString(); } )
               .Fill(c => c.ServiceNumber, c => { return Guid.NewGuid().ToString(); } )
                .Fill(c => c.Network).WithRandom(new string[] {
                    "LAN1",
                    "LAN2",
                    "LAN3",
                    "LAN4",
                    "LAN5",
                    "VLAN1",
                    "VLAN2",
                    "VLAN3",
                    "VLAN4",
                    "VLAN5",
                    "WLAN1",
                    "WLAN2",
                    "WLAN3",
                    "WLAN4",
                    "WLAN5"
                })        
                .Fill(c => c.NetworkIpAddress).WithRandom( new string[] {
                    "192.168.2.1",
                    "192.168.2.2",
                    "192.168.2.3",
                    "192.168.2.4",
                    "192.168.2.5",
                    "192.168.2.6",
                    "192.168.2.7",
                    "192.168.2.8",
                    "192.168.2.9",
                    "192.168.2.10",
                    "192.168.2.11",
                    "192.168.2.12",
                    "192.168.2.13",
                    "192.168.2.14",
                    "192.168.2.15",
                    "192.168.2.16",
                    "192.168.2.17",
                    "192.168.2.18",
                    "192.168.2.19",
                    "192.168.2.20",
                    "172.3.100.1",
                    "172.3.100.2",
                    "172.3.100.3",
                    "172.3.100.4",
                    "172.3.100.5",
                    "172.3.100.6",
                    "172.3.100.7",
                    "172.3.100.8",
                    "172.3.100.9",
                    "172.3.100.10",
                    "172.3.100.11",
                    "172.3.100.12",
                    "172.3.100.13",
                    "172.3.100.14",
                    "172.3.100.15",
                    "172.3.100.16",
                    "172.3.100.17",
                    "172.3.100.18",
                    "172.3.100.19",
                    "172.3.100.20",
                    "10.1.55.1",
                    "10.1.55.2",
                    "10.1.55.3",
                    "10.1.55.4",
                    "10.1.55.5",
                    "10.1.55.6",
                    "10.1.55.7",
                    "10.1.55.8",
                    "10.1.55.9",
                    "10.1.55.10",
                    "10.1.55.11",
                    "10.1.55.12",
                    "10.1.55.13",
                    "10.1.55.14",
                    "10.1.55.15",
                    "10.1.55.16",
                    "10.1.55.17",
                    "10.1.55.18",
                    "10.1.55.19",
                    "10.1.55.20"
                }) 
               .Fill(c => c.Memory, c => { return 4; } )
               .Fill(c => c.Active).WithRandom( new bool[] { true, true, false})
               .Fill(c => c.Replace).WithRandom( new bool[] { true, true, false});
              


            var computers = A.ListOf<Computer>(items);

            foreach (var item in computers)
            {
                Console.WriteLine($"{item.Name} {item.LastUpdate}");
            }

            using (var ctx = _context) {
                foreach (var item in computers)
                {
                    ctx.Computer.Add(item);
                    ctx.SaveChanges();
                }
            }

        }
    }
}
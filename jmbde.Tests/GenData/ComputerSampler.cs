using System;
using System.Collections.Generic;
using GenFu;

using jmbde.Data;

namespace jmbde.Tests.GenData {
    class ComputerSampler {
        List<Computer> computers;

        public ComputerSampler(int count) {
//             var i = 1;

//             A.Configure<Computer>()
//                 .Fill(c => c.ComputerId, () => { return i; } )
//                 .Fill(c => c.NetworkName, () => { return "PC" + String.Format("{0000}",i++); })
//                 .Fill(c => c.Serialnumber, () => { return "S/N" + String.Format("{000000}", i++); })
//                 .Fill(c => c.ServiceTag, () => { return "TAG" + String.Format("{000000}", i++); })
//                 .Fill(c => c.Network, () => { return "NETWORK" + String.Format("{000000}", i++); });

//             computers = A.ListOf<Computer>(count);     
        }

        public void ToDatabase() {
//             using (var db = new jmbdesqliteContext())
//             {
//                 Random rnd = new Random();

//                 foreach (var computer in computers)
//                 {
//                     db.Computer.Add(
//                         new Computer {
//                             NetworkName = computer.NetworkName,
//                             Serialnumber = computer.Serialnumber,
//                             ServiceTag = computer.ServiceTag,
//                             Network = computer.Network,
//                             EmployeeId =  rnd.Next()
//                         }
//                     );
//                 }
//                var count = db.SaveChanges();
//                Console.WriteLine("{0} records saved to database", count);
//             }
        }
    }
}
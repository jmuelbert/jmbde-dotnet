using System;
using System.Collections.Generic;
using GenFu;

using jmbde.Data;

namespace jmbde.Tests.GenData  {
    class MobileSampler {

        List<Mobile> mobiles;

        public MobileSampler(int count) {
//             var i = 1;

//             A.Configure<Mobile>()
//                 .Fill(m => m.MobileId, () => { return i++;})
//                 .Fill(m => m.Number).AsPhoneNumber();

//             mobiles = A.ListOf<Mobile>(count);
        }

        public void ToDatabase() {
//           using (var db = new jmbdesqliteContext())
//             {
//                 Random rnd = new Random();

//                 foreach (var mobile in mobiles)
//                 {
//                     db.Mobile.Add(
//                         new Mobile {
//                             Number = mobile.Number,
//                             EmployeeId = rnd.Next()
//                         }
//                     );
//                 }
//                 var count = db.SaveChanges();
//                 Console.WriteLine("{0} records saved to database", count);
//             }
        }
   }
}
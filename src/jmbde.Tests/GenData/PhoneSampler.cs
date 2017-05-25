using System;
using System.Collections.Generic;
using GenFu;

using jmbde.Data;

namespace jmbde.Tests.GenData  {

    class PhoneSampler {

        List<Phone> phones;

        public PhoneSampler(int count) {
//             var i = 1;

//             A.Configure<Phone>()
//                 .Fill(m => m.PhoneId, () => { return i++;})
//                 .Fill(m => m.Number, () => { return String.Format("{0000}",i++); });

//             phones = A.ListOf<Phone>(count);
        }

        public void ToDatabase() {
//           using (var db = new jmbdesqliteContext())
//             {
//                 Random rnd = new Random();

//                 foreach (var phone in phones)
//                 {
//                     db.Phone.Add(
//                         new Phone {
//                             Number = phone.Number,
//                             EmployeeId = rnd.Next()
//                         }
//                     );
//                 }
//                var count = db.SaveChanges();
//                Console.WriteLine("{0} records saved to database", count);
//             }
        }
    }
}
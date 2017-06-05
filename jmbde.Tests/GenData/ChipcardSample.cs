using System;
using System.Text;
using System.Collections.Generic;
using GenFu;

using jmbde.Data;

namespace jmbde.Tests.GenData {

    class ChipcardSampler {
        List<Chipcard> chipcards;

        public ChipcardSampler(int count)
        {
            var i = 1;

            A.Configure<Chipcard>()
                .Fill(a => a.ChipcardId, () => { return i; } )
                .Fill(a => a.Nummer).AsLastName()
                .Fill(a => a.isActive).WithRandom(new bool[] { true, true, false });
      
            chipcards = A.ListOf<Chipcard>(count);
        }

        public void ToDatabase()
        {
            var saves = 0;

            using (var db = new jmbdesqliteContext())
            {
   
              foreach (var chipcard in chipcards)
                 {
                    db.Chipcard.Add(
                        new Chipcard {
                           Nummer = chipcard.Nummer,
                           isActive = chipcard.isActive,
                           Timestamp = chipcard.Timestamp
                        }
                    );
                }
               saves = db.SaveChanges();
               Console.WriteLine("{0} records saved to database", saves);
            }
        }

        private string GetTimestamp() {
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            Console.WriteLine("Timestamp {0}", sqlFormattedDate);
            return sqlFormattedDate;
        }
    }
}
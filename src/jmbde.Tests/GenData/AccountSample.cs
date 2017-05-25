using System;
using System.Text;
using System.Collections.Generic;
using GenFu;

using jmbde.Data;

namespace jmbde.Tests.GenData {

    class AccountSampler {
        List<Account> accounts;
        List<Employeeaccount> employeeaccounts;
        List<Systemdata> systemdatas;

        public AccountSampler(int count)
        {
            var i = 1;
    
            A.Configure<Systemdata>()
             .Fill(s => s.SystemdataId, () => { return i; })
             .Fill(s => s.Name).AsLastName()
             .Fill(s => s.isLocal).WithRandom(new bool[] { true, true, false })
             .Fill(s => s.Company).AsLastName()
             .Fill(s => s.Address).AsAddress()
             .Fill(s => s.Address2).AsAddressLine2();
           systemdatas = A.ListOf<Systemdata>(count);

            A.Configure<Account>()
                .Fill(a => a.AccountId, () => { return i; } )
                .Fill(a => a.Username).AsLastName()
                .Fill(a => a.Password).AsLastName();
            accounts = A.ListOf<Account>(count);

        //     A.Configure<Employeeaccount>() 
        //      .Fill(s => s.EmployeeaccountId, () => { return i; })
        //      .Fill(s => s.EmployeeId).WithRandom( count * 2)
        //      .Fill(s => e.AccountId).WithRandom(accounts);
        //    employeeaccounts = A.ListOf<Employeeaccount>(count);
        }

        public void ToDatabase()
        {
            var saves = 0;

            using (var db = new jmbdesqliteContext())
            {
                foreach (var systemdata in systemdatas)
                {
                    db.Systemdata.Add(
                        new Systemdata {
                            Name = systemdata.Name,
                            isLocal = systemdata.isLocal,
                            Company = systemdata.Company,
                            Address = systemdata.Address,
                            Address2 = systemdata.Address2,
                            AccountId = systemdata.AccountId
                        }
                    );
                }
                saves = db.SaveChanges();

                foreach (var account in accounts)
                 {
                    db.Account.Add(
                        new Account {
                           Username = account.Username,
                           Password = account.Password,
                           SystemdataId = account.SystemdataId
                           // Timestamp = Encoding.Unicode.GetBytes(GetTimestamp())
                        }
                    );
                }
                saves = db.SaveChanges();

                Console.WriteLine("{0} records saved to database", saves);


                // foreach (var employeeaccount in employeeaccounts)
                // {
                

                //     db.Employeeaccount.Add(
                //         new Employeeaccount {
                //            EmployeeId = employeeaccount.EmployeeId,
                //            AccountId = employeeaccount.AccountId,
                //            Employee = employeeaccount.Employee,
                //            Timestamp = Encoding.Unicode.GetBytes(GetTimestamp())
                //         }
                //     );
                // }
                // saves = db.SaveChanges();
                // Console.WriteLine("{0} records saved to database", saves);
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
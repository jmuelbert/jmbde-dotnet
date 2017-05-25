using System;
using System.Collections.Generic;
using GenFu;

using jmbde.Data;

namespace jmbde.Tests.GenData {
   class EmployeeSampler {

        List<Employee> employees;

        public EmployeeSampler(int count)  {
//             var i = 1;
//             A.Configure<Employee>()
//                 .Fill(e => e.EmployeeId, () => { return i;})
//                 .Fill(e => e.EmployeeNr, () => { return i++; })
//                 .Fill(e => e.Lastname).AsLastName()
//                 // cd ...Fill(e => e.Gender).WithRandom(new string[] {  "M", "M", "W"})
//                 .Fill(e => e.Homemobile).AsPhoneNumber()
//                 .Fill(e => e.Homeemail, e => $"{e.Firstname}.{e.Lastname}@privat.com")
//                 .Fill(e => e.Businessemail, e => $"{e.Firstname}.{e.Lastname}@business.com")
//                 .Fill(e => e.Notes).AsLoremIpsumSentences();
//             employees = A.ListOf<Employee>(count);
        }

        public void ToDatabase() {
//             using (var db = new jmbdesqliteContext())
//             {
//                 foreach (var employee in employees)
//                 {
//                     db.Employee.Add(
//                     new Employee {
//                             Firstname = employee.Firstname,
//                             Lastname = employee.Lastname,
//                             Gender = employee.Gender,
//                             ZipcityId = employee.ZipcityId,
//                             Address = employee.Address,
//                             Homephone = employee.Homephone,
//                             Homemobile = employee.Homemobile,
//                             Homeemail = employee.Homeemail,
//                             Birthday = employee.Birthday,
//                             EmployeeNr = employee.EmployeeNr,
//                             Businessemail = employee.Businessemail,
//                             Datacare = employee.Datacare,
//                             Active = employee.Active,
//                             Startdate = employee.Startdate,
//                             Enddate = employee.Enddate,
//                             DepartmentId = employee.DepartmentId,
//                             FunctionId = employee.FunctionId,
//                             ChipcardId = employee.ChipcardId,
//                             Notes = employee.Notes
//                     }
//                     );    
//                 }
//                 var count = db.SaveChanges();
//                Console.WriteLine("{0} records saved to database", count);
//             }
        }
   }
} 
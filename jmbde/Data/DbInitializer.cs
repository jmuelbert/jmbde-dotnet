using System;
using System.Linq;
using System.Collections.Generic;
using GenFu;

using jmbde.Models;

namespace jmbde.Data
{
    public static class DbInitializer
    {
        public static void Initialize(jmbdesqliteContext context)
        {
             context.Database.EnsureCreated();

             // Look for any Employees.
             if (context.Employee.Any())
             {
                 return; // DB has been seeded
             }
             const int EMPLOYEE = 500;
             const int ACCOUNTS = (EMPLOYEE/5)*4;
             const int CHIPCARDS = (EMPLOYEE/6)*5;
             const int DEVICES = (EMPLOYEE/3)*2;
             const int DEVICETYPES = 10;
             const int COMPANIES = 15;
             const int PLACES = (EMPLOYEE/3)*2;

            AddEmployees(context, EMPLOYEE, 15);
            AddAccounts(context, ACCOUNTS, COMPANIES);
            AddChipcards(context, CHIPCARDS);
            AddChipcarddoors(context, EMPLOYEE/5, COMPANIES);
            AddChipcardprofiles(context, EMPLOYEE/6, COMPANIES);
            AddCities(context,20);
            AddDevices(context, DEVICES, EMPLOYEE, COMPANIES, PLACES);
            AddCompanies(context, 10);
            AddDepartments(context);
            AddDevicenames(context, EMPLOYEE);
            AddDeviceTypes(context);
            AddDocuments(context);
            AddFaxes(context, EMPLOYEE, COMPANIES, PLACES);
            AddFunctions(context);
            AddInventories(context);
            AddMobiles(context, EMPLOYEE/6, EMPLOYEE, PLACES);
            AddPhones(context, (EMPLOYEE/4)*3, EMPLOYEE, PLACES);
            AddOs(context);
            AddPlaces(context, PLACES, COMPANIES);
            AddPrinters(context, EMPLOYEE/7, EMPLOYEE, PLACES);
            AddProcessors(context);
            AddSoftware(context);
            AddTitles(context, 20);

        }

        public static void AddEmployees(jmbdesqliteContext context, int count, int companies)
        {
            List<Employee> employees;

            var i = 1;
            A.Configure<Employee>()
                .Fill(e => e.ID, () => { return i; } )
                .Fill(e => e.Nr, () => { return String.Format("MA-{0000}", i++); } ) 
                // .Fill(e => e.Gender, () =>  new List<Gender>() { Gender.O, Gender.F, Gender.M } )
                .Fill(e => e.Gender).WithRandom(new string[] {  "M", "M", "W"})
                .Fill(e => e.Firstname).AsFirstName()
                .Fill(e => e.Middlename).AsFirstName()
                .Fill(e => e.Lastname).AsLastName()
                .Fill(e => e.Birthday).AsPastDate()
                .Fill(e => e.Address)
                .Fill(e => e.CityID).WithinRange(0, 99999)
                .Fill(e => e.Datacare).WithRandom(new bool[] { true, true, false })
                .Fill(e => e.Active).WithRandom(new bool[] { true, true, false })
                .Fill(e => e.Homephone).AsPhoneNumber()
                .Fill(e => e.Homemobile).AsPhoneNumber()
                .Fill(e => e.Homeemail, e => $"{e.Firstname}.{e.Lastname}@privat.com")
                .Fill(e => e.Businessemail, e => $"{e.Firstname}.{e.Lastname}@business.com")
                .Fill(e => e.Notes).AsLoremIpsumSentences()
                .Fill(e => e.Startdate).AsPastDate()
                .Fill(e => e.Enddate).AsFutureDate()
                .Fill(e => e.CompanyID).WithinRange(0, companies)
                .Fill(e => e.PhoneID).WithinRange(0, (count/3))
                .Fill(e => e.MobileID).WithinRange(0, (count/6))
                .Fill(e => e.FaxID).WithinRange(0, (count/3))
                .Fill(e => e.ChipcardID).WithinRange(0, (count/2))
                .Fill(e => e.Timestamp).AsPastDate();
            employees = A.ListOf<Employee>(count);

            foreach (Employee e in employees)
             {
                 context.Employee.Add(e);
             }
             context.SaveChanges();
        }

        public static void AddAccounts(jmbdesqliteContext context, int count, int companies)
        {
            List<Account> accounts;

            var i=1;

            A.Configure<Account>()
                .Fill(e => e.ID, () => { return i; } )
                .Fill(e => e.Username, () => { return String.Format("USER{0000}", i++); } ) 
                .Fill(e => e.Password, () => { return String.Format("PASSOWRD{0000}", i); } )     
                .Fill(e => e.Active).WithRandom(new bool[] { true, true, false })
                .Fill(e => e.CompanyID).WithinRange(0, (count/3))
                .Fill(e => e.Timestamp).AsPastDate();
            accounts = A.ListOf<Account>(count);

            foreach (Account a in accounts)
            {
                context.Account.Add(a);
            }
            context.SaveChanges();
        }

        public static void AddChipcards(jmbdesqliteContext context, int count)
        {
            List<Chipcard> chipcards;

            var i=1;

            A.Configure<Chipcard>()
                .Fill(e => e.ID, () => { return i; } )
                .Fill(e => e.Number, () => { return String.Format("{0000}", i++); } ) 
                .Fill(e => e.Active).WithRandom(new bool[] { true, true, false })
                .Fill(e => e.EmployeeID).WithinRange(0, (count))
                .Fill(e => e.Timestamp).AsPastDate();
            chipcards = A.ListOf<Chipcard>(count);

            foreach (Chipcard c in chipcards)
            {
                context.Chipcard.Add(c);
            }
            context.SaveChanges();
        }

        public static void AddChipcarddoors(jmbdesqliteContext context, int count, int companies)
        {
            List<Chipcarddoor> chipcarddoors;

            var i=1;

            A.Configure<Chipcarddoor>()
                .Fill(e => e.ID, () => { return i; } )
                .Fill(e => e.Name, () => { return String.Format("Door{0000}", i++); } ) 
                .Fill(e => e.Active).WithRandom(new bool[] { true, true, false })
                .Fill(e => e.CompanyID).WithinRange(0, companies)
                .Fill(e => e.Timestamp).AsPastDate();
            chipcarddoors = A.ListOf<Chipcarddoor>(count);

            foreach (Chipcarddoor c in chipcarddoors)
            {
                context.Chipcarddoor.Add(c);
            }    
            context.SaveChanges();
        }

        public static void AddChipcardprofiles(jmbdesqliteContext context, int count, int companies)
        {
            List<Chipcardprofile> chipcardprofiles;

            var i = 1;

            A.Configure<Chipcardprofile>()
                .Fill(e => e.ID, () => { return i; } )
                .Fill(e => e.Name, () => { return String.Format("Profile{0000}", i++); } ) 
                .Fill(e => e.Active).WithRandom(new bool[] { true, true, false })
                .Fill(e => e.CompanyID).WithinRange(0, companies)
                .Fill(e => e.Timestamp).AsPastDate();
            chipcardprofiles = A.ListOf<Chipcardprofile>(count);

            foreach (Chipcardprofile c in chipcardprofiles)
            {
                context.Chipcardprofile.Add(c);
            }
            context.SaveChanges();
        }

        public static void AddCities(jmbdesqliteContext context, int count)
        {
            List<City> cities;

            var i = 1;

            A.Configure<City>()
                .Fill(e => e.ID, () => { return i++; } )
                .Fill(e => e.Name).AsCity()
                .Fill(e => e.Timestamp).AsPastDate();
            cities = A.ListOf<City>(count);

            foreach (City c in cities)
            {
                context.City.Add(c);
            }
            context.SaveChanges();
        }

        public static void AddCompanies(jmbdesqliteContext context, int count)
        {
            List<Company> companies;

            var i = 1;

            A.Configure<Company>()
                .Fill(e => e.ID, () => { return i++; } ) 
                .Fill(e => e.TitleID).WithinRange(1,20)
                .Fill(e => e.Firstname).AsFirstName()
                .Fill(e => e.Lastname).AsLastName()
                .Fill(e => e.Name).AsLastName()
                .Fill(e => e.Name2).AsFirstName()
                .Fill(e => e.Address).AsAddress()
                .Fill(e => e.Address2).AsAddressLine2()
                .Fill(e => e.CityID).WithinRange(1, 99999)
                .Fill(e => e.Email).AsEmailAddress()
                .Fill(e => e.Phone).AsPhoneNumber()
                .Fill(e => e.Fax).AsPhoneNumber()
                .Fill(e => e.Timestamp).AsPastDate();           
            companies = A.ListOf<Company>(count);

            foreach (Company c in companies)
            {
                context.Company.Add(c);
            }
            context.SaveChanges();                
        }

#region Devices    

        public static void AddDevices(jmbdesqliteContext context, int count, int employee, int companies, int places)
        {
            List<Device> devices;

            var i = 1;

            A.Configure<Device>()
                .Fill(e => e.ID, () => { return i++; } )
                .Fill(e => e.Serialnumber, () => { return String.Format("SN{00000000}", i++); } ) 
                .Fill(e => e.ServiceTag, () => { return String.Format("ST{00000000}", i++); } ) 
                .Fill(e => e.ServiceNumber, () => { return String.Format("ServiceNumber{00000000}", i++); } )
                .Fill(e => e.Memory).WithinRange((4*1024), (64*1024) )
                .Fill(e => e.Network).WithRandom(new string[] {  "LAN1", "LAN2", "WLAN1", "WLAN2", "VLAN", "EXTERN"})
                .Fill(e => e.NetworkName).WithRandom(new string[] {  "COMP1LAN", "COMP2LAN", "COMP2WLAN", "COMP3WLAN", "VLAN", "EXTERN"})
                .Fill(e => e.Active).WithRandom(new bool[] { true, true, false })
                .Fill(e => e.Replace).WithRandom(new bool[] { false, false, true })
                .Fill(e => e.EmployeeID).WithinRange(0, (employee/5)*4)
                .Fill(e => e.CompanyID).WithinRange(0, companies)
                .Fill(e => e.DevicetypeID).WithinRange(0, 10)
                .Fill(e => e.DevicenameID).WithinRange(0, (count*2))     
                .Fill(e => e.PlaceID).WithinRange(0, places)
                .Fill(e => e.ManufacturerID).WithinRange(0,15)
                .Fill(e => e.InventoryID).WithinRange(0, (count*2))
                .Fill(e => e.ProcessorID).WithinRange(0, 10)
                .Fill(e => e.OsID).WithinRange(0, 10)
                .Fill(e => e.Timestamp).AsPastDate();
            devices = A.ListOf<Device>(count);

            foreach (Device c in devices)
            {
                context.Device.Add(c);
            }
            context.SaveChanges();
        }

        public static void AddFaxes(jmbdesqliteContext context, int count, int companies, int places)
        {
            List<Fax> faxes;

            var i = 1;

            A.Configure<Fax>()
                .Fill(e => e.ID, () => { return i++; } )  
                .Fill(e => e.Number, () => { return String.Format("{0000}", i); } )   
                .Fill(e => e.Pin, () => { return String.Format("Pin{0000}", i); } )             
                .Fill(e => e.Serialnumber, () => { return String.Format("SN{000000000}", i); } ) 
                .Fill(e => e.Active).WithRandom(new bool[] { true, true, false })
                .Fill(e => e.Replace).WithRandom(new bool[] { false, false, true })
                .Fill(e => e.DevicetypeID).WithinRange(0, 10)
                .Fill(e => e.DevicenameID).WithinRange(0, count/10) 
                .Fill(e => e.EmployeeID).WithinRange(0, count)  
                .Fill(e => e.CompanyID).WithinRange(0, companies)  
                .Fill(e => e.PlaceID).WithinRange(0, places)
                .Fill(e => e.DepartmentID).WithinRange(0, 10)                
                .Fill(e => e.InventoryID).WithinRange(0, count/10)
                .Fill(e => e.PrinterID).WithinRange(0, 10)                
                .Fill(e => e.Timestamp).AsPastDate();           
            faxes = A.ListOf<Fax>(count/10);

            foreach (Fax f in faxes)
            {
                context.Fax.Add(f);
            }
            context.SaveChanges();
        }

        public static void AddPrinters(jmbdesqliteContext context, int count, int employees, int places)
        {
            List<Printer> printers;

            var i = 1;

            A.Configure<Printer>()
                .Fill(e => e.ID, () => { return i++; } )
                .Fill(e => e.Serialnumber, () => { return String.Format("SN{00000000}", i++); } ) 
                .Fill(e => e.Network).WithRandom(new string[] {  "LAN1", "LAN2", "WLAN1", "WLAN2", "VLAN", "EXTERN"})
                .Fill(e => e.NetworkName).WithRandom(new string[] {  "COMP1LAN", "COMP2LAN", "COMP2WLAN", "COMP3WLAN", "VLAN", "EXTERN"})
                .Fill(e => e.Active).WithRandom(new bool[] { true, true, false })
                .Fill(e => e.Replace).WithRandom(new bool[] { false, false, true })
                .Fill(e => e.Resources).WithRandom(new string[] {"TONER1", "TONER2", "TONER3", "TONER4", "TONER5", "TONER6"})
                .Fill(e => e.PapersizeMax).WithRandom(new string[] { "A4", "A4", "A3", "LABEL"})
                .Fill(e => e.Color).WithRandom(new bool[] { false, false, true})
                .Fill(e => e.EmployeeID).WithinRange(0, (employees/7)*2)
                .Fill(e => e.DevicetypeID).WithinRange(0, 10)
                .Fill(e => e.DevicenameID).WithinRange(0, (count*2))     
                .Fill(e => e.PlaceID).WithinRange(0, places)
                .Fill(e => e.CompanyID).WithinRange(0,15)
                .Fill(e => e.InventoryID).WithinRange(0, (count*2))
                .Fill(e => e.Timestamp).AsPastDate();
            printers = A.ListOf<Printer>(count);

            foreach (Printer p in printers)
            {
                context.Printer.Add(p);
            }
            context.SaveChanges();   
        }

        public static void AddMobiles(jmbdesqliteContext context, int count, int empcount, int places)
        {
            List<Mobile> mobiles;

            var i = 1;

            A.Configure<Mobile>()
                .Fill(e => e.ID, () => { return i++; } )  
                .Fill(e => e.Number, () => { return String.Format("{0000}", i); } )   
                .Fill(e => e.Cardnumber, () => { return new Guid().ToString(); })
                .Fill(e => e.Activatedate).AsPastDate()
                .Fill(e => e.Pin, () => { return String.Format("Pin{0000}", i); } )             
                .Fill(e => e.Serialnumber, () => { return String.Format("SN{000000000}", i); } ) 
                .Fill(e => e.Active).WithRandom(new bool[] { true, true, false })
                .Fill(e => e.Replace).WithRandom(new bool[] { false, false, true })
                .Fill(e => e.EmployeeID).WithinRange(0, empcount)
                .Fill(e => e.DevicetypeID).WithinRange(0, 10)
                .Fill(e => e.DevicenameID).WithinRange(0, (count*2))     
                .Fill(e => e.PlaceID).WithinRange(0, places)
                .Fill(e => e.DepartmentID).WithinRange(0, 10)                
                .Fill(e => e.CompanyID).WithinRange(0,15)
                .Fill(e => e.InventoryID).WithinRange(0, (count*2))               
                .Fill(e => e.Timestamp).AsPastDate();           
            mobiles = A.ListOf<Mobile>(count);

            foreach (Mobile m in mobiles)
            {
                context.Mobile.Add(m);
            }
            context.SaveChanges();
        }

        public static void AddPhones(jmbdesqliteContext context, int count, int empcount, int places)
        {
            List<Phone> phones;

            var i = 1;

            A.Configure<Phone>()
                .Fill(e => e.ID, () => { return i++; } )  
                .Fill(e => e.Number, () => { return String.Format("{0000}", i); } )   
                .Fill(e => e.Pin, () => { return String.Format("Pin{0000}", i); } )             
                .Fill(e => e.Serialnumber, () => { return String.Format("SN{000000000}", i); } ) 
                .Fill(e => e.Active).WithRandom(new bool[] { true, true, false })
                .Fill(e => e.Replace).WithRandom(new bool[] { false, false, true })
                .Fill(e => e.EmployeeID).WithinRange(0, empcount)
                .Fill(e => e.DevicetypeID).WithinRange(0, 10)
                .Fill(e => e.DevicenameID).WithinRange(0, (count*2))     
                .Fill(e => e.PlaceID).WithinRange(0, places)
                .Fill(e => e.DepartmentID).WithinRange(0, 10)                
                .Fill(e => e.CompanyID).WithinRange(0,15)
                .Fill(e => e.InventoryID).WithinRange(0, (count*2))               
                .Fill(e => e.Timestamp).AsPastDate();           
            phones = A.ListOf<Phone>(count);

            foreach (Phone p in phones)
            {
                context.Phone.Add(p);
            }
            context.SaveChanges();

        }

        public static void AddDevicenames(jmbdesqliteContext context, int count)
        {
            string[] types = { "PC", "PRINTER", "PAD", "PHONE", "MOBILE", "FAX" };
            int[] number = { (count/6)*5, count/10, count/15, (count/5)*4, count/4, count/3 };

            var i = 1;

            foreach (var type in types)
            {
                List<Devicename> devicenames;

                A.Configure<Devicename>()
                    .Fill(e => e.ID, () => { return i++; } )  
                    .Fill(e => e.Name, () => { return String.Format(type + "{0000}", i); } ) 
                    .Fill(e => e.Timestamp).AsPastDate();              
                devicenames = A.ListOf<Devicename>(count);

                foreach (Devicename d in devicenames)
                {
                    context.Devicename.Add(d);
                }
                context.SaveChanges();
            }
        }

        public static void AddDeviceTypes(jmbdesqliteContext context)
        {
            var devicetypes = new Devicetype[]
            {
                new Devicetype{Name="Computer", Timestamp=DateTime.Parse("10.06.2017")},
                new Devicetype{Name="Printer", Timestamp=DateTime.Parse("10.06.2017")},
                new Devicetype{Name="Pad", Timestamp=DateTime.Parse("10.06.2017")},
                new Devicetype{Name="Dect Phone", Timestamp=DateTime.Parse("10.06.2017")},
                new Devicetype{Name="Phone", Timestamp=DateTime.Parse("10.06.2017")},
                new Devicetype{Name="Mobile", Timestamp=DateTime.Parse("10.06.2017")},
                new Devicetype{Name="Fax", Timestamp=DateTime.Parse("10.06.2017")},
                new Devicetype{Name="Copier", Timestamp=DateTime.Parse("10.06.2017")},
                new Devicetype{Name="Server", Timestamp=DateTime.Parse("10.06.2017")},
                new Devicetype{Name="USP", Timestamp=DateTime.Parse("10.06.2017")},
                new Devicetype{Name="Switch", Timestamp=DateTime.Parse("10.06.2017")},
                new Devicetype{Name="Router", Timestamp=DateTime.Parse("10.06.2017")}
            };
            foreach (Devicetype d in devicetypes)       
            {
                context.Devicetype.Add(d);
            }
            context.SaveChanges();
        }

#endregion

#region Company

        public static void AddDepartments(jmbdesqliteContext context)
        {
            var departments = new Department[]
            {
                new Department{Name="Human Resources", Prio=2, Timestamp=DateTime.Parse("10.06.2017")},
                new Department{Name="Accounting", Prio=3, Timestamp=DateTime.Parse("10.06.2017")},
                new Department{Name="Sales", Prio=4, Timestamp=DateTime.Parse("10.06.2017")},
                new Department{Name="Store", Prio=5, Timestamp=DateTime.Parse("10.06.2017")},
                new Department{Name="Marketing", Prio=6, Timestamp=DateTime.Parse("10.06.2017")},
                new Department{Name="IT", Prio=7, Timestamp=DateTime.Parse("10.06.2017")},
                new Department{Name="Delivery", Prio=8, Timestamp=DateTime.Parse("10.06.2017")},
                new Department{Name="House Keeping", Prio=9, Timestamp=DateTime.Parse("10.06.2017")}
            };
            foreach (Department d in departments)       
            {
                context.Department.Add(d);
            }
            context.SaveChanges();
        }

        public static void AddFunctions(jmbdesqliteContext context)
        {
            var functions = new Function[]
            {
                new Function{Name="Manager", Prio=1, Timestamp=DateTime.Parse("11.06.2017")},
                new Function{Name="Human Resources Manager", Prio=2, Timestamp=DateTime.Parse("11.06.2017")},
                new Function{Name="Accounting Manager", Prio=3, Timestamp=DateTime.Parse("11.06.2017")},
                new Function{Name="Accounting Staff", Prio=4,  Timestamp=DateTime.Parse("11.06.2017")},
                new Function{Name="Sales Manager", Prio=5, Timestamp=DateTime.Parse("11.06.2017")},
                new Function{Name="Sales Stuff", Prio=6, Timestamp=DateTime.Parse("11.06.2017")},
                new Function{Name="Store Manager", Prio=7, Timestamp=DateTime.Parse("11.06.2017")},
                new Function{Name="Store Staff", Prio=8, Timestamp=DateTime.Parse("11.06.2017")},
                new Function{Name="Marketing Manager", Prio=9, Timestamp=DateTime.Parse("11.06.2017")},
                new Function{Name="Marketing Staff", Prio=10, Timestamp=DateTime.Parse("11.06.2017")},
                new Function{Name="IT Manager", Prio=11, Timestamp=DateTime.Parse("11.06.2017")},
                new Function{Name="IT Staff", Prio=12, Timestamp=DateTime.Parse("11.06.2017")},
                new Function{Name="Delivery Manager", Prio=13, Timestamp=DateTime.Parse("11.06.2017")},
                new Function{Name="Delivery Staff", Prio=14, Timestamp=DateTime.Parse("11.06.2017")},
                new Function{Name="Facility Manager", Prio=15, Timestamp=DateTime.Parse("11.06.2017")}
            };
            foreach (Function f in functions)
            {
                context.Function.Add(f);
            }
            context.SaveChanges();
        }

        public static void AddPlaces(jmbdesqliteContext context, int count, int companies)
        {
            List<Place> places;

            var i = 1;

            A.Configure<Place>()
                .Fill(e => e.ID, () => { return i++; } )  
                .Fill(e => e.Name).AsUsaState()
                .Fill(e => e.Room, () => { return String.Format("{0000}", i); })
                .Fill(e => e.Desk).AsCanadianProvince()
                .Fill(e => e.CompanyID).WithinRange(0, companies)
                .Fill(e => e.Timestamp).AsPastDate();           
            places = A.ListOf<Place>(count);

            foreach (Place p in places)
            {
                context.Place.Add(p);
            }
            context.SaveChanges();

        }

        public static void AddInventories(jmbdesqliteContext context)
        {
            var inventories = new Inventory[]
            {   
                new Inventory{Number="0000-0001", Text="Desk from Manager",Active=true, PlaceID=1, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0001-0001", Text="Server", Active=true, PlaceID=2, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0001-0002", Text="Server Old", Active=false, PlaceID=2, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0002-0001", Text="IPhone", Active=true, PlaceID=5, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0004-0001", Text="Computer 0001", Active=true, PlaceID=5, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0004-0002", Text="Computer 0002", Active=true, PlaceID=6, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0004-0003", Text="Computer 0003", Active=true, PlaceID=7, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0004-0004", Text="Computer 0004", Active=true, PlaceID=8, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0004-0005", Text="Computer 0005", Active=true, PlaceID=9, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0004-0006", Text="Computer 0006", Active=true, PlaceID=10, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0004-0007", Text="Computer 0007", Active=false, PlaceID=10, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0004-0008", Text="Computer 0008", Active=true, PlaceID=11, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0004-0009", Text="Computer 0009", Active=true, PlaceID=12, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0004-0010", Text="Computer 0010", Active=true, PlaceID=13, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0004-0011", Text="Computer 0011", Active=true, PlaceID=14, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0004-0012", Text="Computer 0012", Active=true, PlaceID=15, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0004-0013", Text="Computer 0013", Active=true, PlaceID=16, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0004-0014", Text="Computer 0014", Active=true, PlaceID=17, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0004-0015", Text="Computer 0015", Active=true, PlaceID=18, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0004-0016", Text="Computer 0016", Active=true, PlaceID=18, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0004-0017", Text="Computer 0017", Active=true, PlaceID=19, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0004-0018", Text="Computer 0018", Active=true, PlaceID=20, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0004-0019", Text="Computer 0019", Active=true, PlaceID=21, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0004-0020", Text="Computer 0020", Active=true, PlaceID=22, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0005-0001", Text="IPhone 0001", Active=true, PlaceID=22, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0005-0002", Text="IPad 0001", Active=true, PlaceID=22, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0006-0001", Text="Laptop 0001", Active=true, PlaceID=23, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0006-0002", Text="Laptop 0002", Active=true, PlaceID=24, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0006-0003", Text="Laptop 0003", Active=true, PlaceID=25, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0006-0004", Text="Laptop 0004", Active=true, PlaceID=26, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0006-0005", Text="Laptop 0005", Active=true, PlaceID=27, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0007-0001", Text="Desk 0001", Active=false, PlaceID=5, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0007-0002", Text="Desk 0002", Active=true, PlaceID=6, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0007-0003", Text="Desk 0002", Active=true, PlaceID=7, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0007-0004", Text="Desk 0003", Active=true, PlaceID=8, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0007-0005", Text="Desk 0004", Active=true, PlaceID=5, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0007-0006", Text="Desk 0005", Active=true, PlaceID=9, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0008-0001", Text="Printer 0001", Active=true, PlaceID=5, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0008-0002", Text="Printer 0002", Active=true, PlaceID=6, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0008-0002", Text="Fax 0001", Active=true, PlaceID=7, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0008-0003", Text="Fax 0002", Active=true, PlaceID=8, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0009-0001", Text="Datasafe 0001", Active=true, PlaceID=30, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0009-0002", Text="Datasafe 0002", Active=true, PlaceID=31, Timestamp=DateTime.Parse("11.06.2017")},
                new Inventory{Number="0009-0003", Text="Datasafe 0003", Active=true, PlaceID=32, Timestamp=DateTime.Parse("11.06.2017")}
            };
            foreach (Inventory inv in inventories)
            {
                context.Inventory.Add(inv);
            }
            context.SaveChanges();
        }

#endregion

        public static void AddDocuments(jmbdesqliteContext context)
        {
            var documents = new Document[]
            {
                new Document{Name="Document1", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},
                new Document{Name="Document2", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},
                new Document{Name="Document3", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},
                new Document{Name="Document4", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},
                new Document{Name="Document5", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},
                new Document{Name="Document6", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},
                new Document{Name="Document7", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},
                new Document{Name="Document8", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},
                new Document{Name="Document9", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},
                new Document{Name="Document10", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},                
                new Document{Name="Document11", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},
                new Document{Name="Document12", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},
                new Document{Name="Document13", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},
                new Document{Name="Document14", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},
                new Document{Name="Document15", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},
                new Document{Name="Document16", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},
                new Document{Name="Document17", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},
                new Document{Name="Document18", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},
                new Document{Name="Document19", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},
                new Document{Name="Document20", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},
                new Document{Name="Document21", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},
                new Document{Name="Document22", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},
                new Document{Name="Document23", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},
                new Document{Name="Document24", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},
                new Document{Name="Document25", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},
                new Document{Name="Document26", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},
                new Document{Name="Document27", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},
                new Document{Name="Document28", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},
                new Document{Name="Document29", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},
                new Document{Name="Document30", MyDocument=new byte[]{65 ,66, 67, 68, 69, 70}, Timestamp=DateTime.Parse("10.06.2017")},
            };
            foreach (Document d in documents)
            {
                context.Document.Add(d);
            }
            context.SaveChanges();
        }




        public static void AddOs(jmbdesqliteContext context)
        {
            var oss = new Os[]
            {
                new Os{Name="Windows 7", Version="7", Revision="0", Fix="0", ManufacturerID=1, Timestamp=DateTime.Parse("11.06.2017") },
                new Os{Name="Windows 7-64", Version="7", Revision="0", Fix="0", ManufacturerID=1, Timestamp=DateTime.Parse("11.06.2017") },
                new Os{Name="Windows 8", Version="8", Revision="0", Fix="0", ManufacturerID=1, Timestamp=DateTime.Parse("11.06.2017") },
                new Os{Name="Windows 8-64", Version="8", Revision="0", Fix="0", ManufacturerID=1, Timestamp=DateTime.Parse("11.06.2017") },
                new Os{Name="Windows 8.1", Version="8", Revision="1", Fix="0", ManufacturerID=1, Timestamp=DateTime.Parse("11.06.2017") },
                new Os{Name="Windows 8.1-64", Version="8", Revision="1", Fix="0", ManufacturerID=1, Timestamp=DateTime.Parse("11.06.2017") },
                new Os{Name="Windows 10", Version="9", Revision="0", Fix="0", ManufacturerID=1, Timestamp=DateTime.Parse("11.06.2017") },
                new Os{Name="Windows 10-64", Version="9", Revision="0", Fix="0", ManufacturerID=1, Timestamp=DateTime.Parse("11.06.2017") },
                new Os{Name="Windows Server 2003", Version="7", Revision="0", Fix="0", ManufacturerID=1, Timestamp=DateTime.Parse("11.06.2017") },
                new Os{Name="Windows Server 2008R2 x64", Version="8", Revision="0", Fix="0", ManufacturerID=1, Timestamp=DateTime.Parse("11.06.2017") },
                new Os{Name="Windows Server 2012R2 x64", Version="9", Revision="0", Fix="0", ManufacturerID=1, Timestamp=DateTime.Parse("11.06.2017") },
                new Os{Name="iOS 10", Version="10", Revision="0", Fix="0", ManufacturerID=1, Timestamp=DateTime.Parse("11.06.2017") }
            };
            foreach (Os o in oss)
            {
                context.Os.Add(o);
            }
            context.SaveChanges();
        }



         public static void AddProcessors(jmbdesqliteContext context)
        {
            var processors = new Processor[]
            {
                new Processor{Name="I3", Ghz=2.1f, Cores=2, Timestamp=DateTime.Parse("11.06.2017") },
                new Processor{Name="I5", Ghz=2.7f, Cores=3, Timestamp=DateTime.Parse("11.06.2017") },
                new Processor{Name="I7", Ghz=2.1f, Cores=5, Timestamp=DateTime.Parse("11.06.2017") },
                new Processor{Name="XEON", Ghz=2.1f, Cores=3, Timestamp=DateTime.Parse("11.06.2017") },
             
            };
            foreach (Processor p in processors)
            {
                context.Processor.Add(p);
            }
            context.SaveChanges();
        }

        public static void AddSoftware(jmbdesqliteContext context)
        {
            var softwarez = new Software[]
            {
                new Software{Name="Acrobat Reader", Version="12", Revision="0", Fix="0", ManufacturerID=1, Timestamp=DateTime.Parse("11.06.2017") },
                new Software{Name="PDF Creator", Version="7", Revision="0", Fix="0", ManufacturerID=1, Timestamp=DateTime.Parse("11.06.2017") },
                new Software{Name="ITunes", Version="8", Revision="0", Fix="0", ManufacturerID=1, Timestamp=DateTime.Parse("11.06.2017") },
                new Software{Name="VLC", Version="8", Revision="0", Fix="0", ManufacturerID=1, Timestamp=DateTime.Parse("11.06.2017") },
                new Software{Name="Office 2010", Version="8", Revision="1", Fix="0", ManufacturerID=1, Timestamp=DateTime.Parse("11.06.2017") },
                new Software{Name="Office 2013", Version="8", Revision="1", Fix="0", ManufacturerID=1, Timestamp=DateTime.Parse("11.06.2017") },
                new Software{Name="Office 2016", Version="9", Revision="0", Fix="0", ManufacturerID=1, Timestamp=DateTime.Parse("11.06.2017") },
                new Software{Name="Java Runtime", Version="9", Revision="0", Fix="0", ManufacturerID=1, Timestamp=DateTime.Parse("11.06.2017") }
            };
            foreach (Software s in softwarez)
            {
                context.Software.Add(s);
            }
            context.SaveChanges();
        }

        public static void AddTitles(jmbdesqliteContext context, int count)
        {
            List<Title> titles;

            var i = 1;

            A.Configure<Title>()
                .Fill(e => e.ID, () => { return i++; } )  
                .Fill(e => e.Name).AsPersonTitle()
                .Fill(e => e.Timestamp).AsPastDate();           
            titles = A.ListOf<Title>(count);

            foreach (Title t in titles)
            {
                context.Title.Add(t);
            }
            context.SaveChanges();
        } 

    }


}
using System;
using System.Collections.Generic;

namespace jmbde.Data
{
    public partial class Employee
    {
        public Employee()
        {
            Computer = new HashSet<Computer>();
            Mobile = new HashSet<Mobile>();
            Phone = new HashSet<Phone>();
        }

        public long EmployeeId { get; set; }
        public long EmployeeNr { get; set; }
        public string Gender { get; set; }
        public long TitleId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Birthday { get; set; }
        public string Address { get; set; }
        public string ZipcityId { get; set; }
        public string Homephone { get; set; }
        public string Homemobile { get; set; }
        public string Homeemail { get; set; }
        public string Businessemail { get; set; }
        public string Datacare { get; set; }
        public string Active { get; set; }
        public byte[] Photo { get; set; }
        public string Notes { get; set; }
        public string Startdate { get; set; }
        public string Enddate { get; set; }
        public long DepartmentId { get; set; }
        public long FunctionId { get; set; }
        public long ComputerId { get; set; }
        public long PrinterId { get; set; }
        public long PhoneId { get; set; }
        public long MobileId { get; set; }
        public long FaxId { get; set; }
        public long EmployeeAccountId { get; set; }
        public long EmployeeDocumentId { get; set; }
        public long ChipcardId { get; set; }
        public string LastUpdate { get; set; }

        public virtual ICollection<Computer> Computer { get; set; }
        public virtual ICollection<Mobile> Mobile { get; set; }
        public virtual ICollection<Phone> Phone { get; set; }
    }
}

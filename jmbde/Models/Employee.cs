using System;
using System.Collections.Generic;

namespace jmbde.Models

{
    public partial class Employee
    {
        public long EmployeeId { get; set; }
        public long? EmployeeNr { get; set; }
        public long? Gender { get; set; }
        public long? TitleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDay { get; set; }
        public string Address { get; set; }
        public long? ZipCityId { get; set; }
        public string HomePhone { get; set; }
        public string HomeMobile { get; set; }
        public string HomeMailAddress { get; set; }
        public string BusinessMailAddress { get; set; }
        public string DataCare { get; set; }
        public string Active { get; set; }
        public byte[] Photo { get; set; }
        public string Notes { get; set; }
        public string HireDate { get; set; }
        public string EndDate { get; set; }
        public long? DepartmentId { get; set; }
        public long? FunctionId { get; set; }
        public long? ComputerId { get; set; }
        public long? PrinterId { get; set; }
        public long? PhoneId { get; set; }
        public long? MobileId { get; set; }
        public long? FaxId { get; set; }
        public long? EmployeeAccountId { get; set; }
        public long? EmployeeDocumentId { get; set; }
        public long? ChipCardId { get; set; }
        public string LastUpdate { get; set; }
    }
}

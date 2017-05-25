using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jmbde.Data
{
    public enum Gender 
    {
        O, F, M
    }

    public partial class Employee
    {
  
        public int EmployeeId { get; set; }
        public long? EmployeeNr { get; set; }
        public Gender? Gender { get; set; }
        public int? TitleId { get; set; }

        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters.")]
        public string Firstname { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters.")]
        public string Lastname { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [StringLength(50, ErrorMessage = "Address cannot be longer than 50 characters.")]
        public string Address { get; set; }
        public string ZipcityId { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Homephone { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Homemobile { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Homeemail { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Businessemail { get; set; }
        public bool Datacare { get; set; }
        public bool isActive { get; set; }
        public byte[] Photo { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
        
        [DataType(DataType.Date)]
        public string Startdate { get; set; }

        [DataType(DataType.Date)]
        public string Enddate { get; set; }

        public int DepartmentId { get; set; }
        public int FunctionId { get; set; }
        public int ComputerId { get; set; }
        public int PrinterId { get; set; }
        public int PhoneId { get; set; }
        public int MobileId { get; set; }
        public int FaxId { get; set; }
        public int EmployeeaAccountId { get; set; }
        public int EmployeeDocumentId { get; set; }
        public int ChipcardId { get; set; }

        [DataType(DataType.DateTime)]
        public string Timestamp { get; set; }

        public Title Title { get; set; }
        public Zipcity Zipcity { get; set; }
        public virtual ICollection<Department> Department { get; set; }     
        public virtual ICollection<Function> Function { get; set; }
        public virtual ICollection<Computer> Computer { get; set; }
        public virtual ICollection<Printer> Printer { get; set; }
        public virtual ICollection<Phone> Phone { get; set; }
        public virtual ICollection<Mobile> Mobile { get; set; }
        public virtual ICollection<Fax> Fax { get; set; }
        public virtual ICollection<Employeeaccount> Employeeaccount { get; set; }
        public virtual ICollection<Employeedocument> Employeedocument { get; set; }
        public Chipcard Chipcard { get; set; }

        public string FullName {
            get { return Lastname + ", " + Firstname; }
        }

    }
}

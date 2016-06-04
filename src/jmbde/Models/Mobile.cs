using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jmbde.Models
{
    /// <summary>
    /// The Class for the Mobile
    /// </summary>
    public partial class Mobile
    {
        /// <summary>
        /// The constructor is empty
        /// may be need them later
        /// </summary>
        /// public Mobile()  { }

        /// <summary>
        /// The MobileId
        /// </summary>
        [Key]
        public int Id { get; set; }


        /// <summary>
        /// The Number of the Mobile
        /// </summary>
        [Required, StringLength(30), Display(Name = "Mobile Number")]
        public string Number { get; set; }

        /// <summary>
        /// Is this Phone active ?
        /// </summary>
        public bool? Active { get; set; }

        /// <summary>
        /// The foreign key for the employee
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// The Connection to the Employee
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// The Date and Time of last touch this DataSet
        /// </summary>
        public DateTime? LastUpdate { get; set; }
    }
}
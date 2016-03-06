using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jmbde.Models
{
    /// <summary>
    /// The Class for the Computer
    /// </summary>
    public partial class Computer
    {
        /// <summary>
        /// The constructor is empty
        /// may be need them later
        /// </summary>
        // public Computer()  { }

        /// <summary>
        /// The ComputerId
        /// </summary>
        [Key]
        public int Id { get; set; }
        
        
        /// <summary>
        /// The Name (id) of the Computer
        /// </summary>
        [Required, Display(Name = "PC Name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Is this Computer active ?
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
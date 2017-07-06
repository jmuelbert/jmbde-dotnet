using System.Collections.Generic; 
using System.ComponentModel.DataAnnotations; 
 
namespace jmbde.Data 
{ 
    public partial class Computer 
    { 
        public int ID { get; set; } 
        
        public string serialNumber { get; set; } 
        public string serviceTag { get; set; } 
        public string serviceNumber { get; set; } 
        public long? memory { get; set; } 
        public string netWork { get; set; } 
        public string networkName { get; set; } 
        public bool active { get; set; } 
        public bool replace { get; set; }

        public int DevicenameId { get; set; } 
        public int DevicetypeId { get; set; } 
        public int? EmployeeId { get; set; } 
        public int PlaceId { get; set; } 
        public int DepartmentId { get; set; } 
        public int ManufacturerId { get; set; } 
        public int InventoryId { get; set; } 
        public int ProcessorId { get; set; } 
        public int OsId { get; set; } 
        public int ComputersoftwareId { get; set; } 
        public int? PrinterId { get; set; } 
 
      
        [DataType(DataType.DateTime)]
        public DateTime created { get; set; }        

        [DataType(DataType.DateTime)]
        public DateTime timeStamp { get; set; }
        
        // Navigation Properties 
        public virtual Devicename Devicename { get; set; } 
        public virtual Devicetype Devicetype { get; set; } 
        public virtual Place Place { get; set; } 
        public virtual ICollection<Department> Department { get; set; } 
        public virtual Manufacturer Manufacturer { get; set; } 
        public virtual Inventory Inventory { get; set; } 
        public virtual Processor Processor { get; set; } 
        public virtual Os Os { get; set; } 
        public virtual ICollection<Computersoftware> Computersoftware { get; set; } 
        public virtual Printer Printer { get; set; } 
        public virtual Employee Employee { get; set; } 
    } 
} 
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace jmbde.Models
{
    /// <summary>
    /// The JMBDEContext
    ///
    /// The ORM Connection to the Database
    /// </summary>
    public partial class JMBDEContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
             options.UseSqlite("Data Source=jmbde.db");       
        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Computer> Computer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Mobile> Mobile { get; set; } 
        public virtual DbSet<Phone> Phone { get; set; }      
    }
}
using Microsoft.Data.Entity;

namespace jmbde.Models
{
    /// <summary>
    /// The JMBDEContext
    ///
    /// The ORM Connection to the Database
    /// </summary>
    // You may need to install the Microsoft.AspNet.Http.Abstractions package into your project
    public class JMBDEContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public virtual DbSet<Company>  Company { get; set; }
        public virtual DbSet<Computer> Computer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Mobile> Mobile { get; set; }
        public virtual DbSet<Phone> Phone { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

using jmbde.Models;

namespace jmbde.Data
{
    public class JMBDEContext : DbContext {
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Computer> Computer { get; set; }
        public virtual DbSet<Mobile> Mobile { get; set; }
        public virtual DbSet<Phone> Phone { get; set; }
        
        public JMBDEContext(DbContextOptions<JMBDEContext> options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

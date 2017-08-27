using Microsoft.EntityFrameworkCore;

using jmbde.Models;

namespace jmbde.Data
{
    public class JMBDEContext : DbContext {
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Computer> Computers { get; set; }
        public virtual DbSet<Mobile> Mobiles { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        
        public JMBDEContext(DbContextOptions<JMBDEContext> options) : base(options)
        {

        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=jmbdeSQLite.db3");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

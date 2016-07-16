/*
 * Copyright 2016 Jürgen Mülbert
 *
 * Licensed under the EUPL, Version 1.1 or – as soon they
   will be approved by the European Commission - subsequent
   versions of the EUPL (the "Licence");
 * You may not use this work except in compliance with the Licence.
 * You may obtain a copy of the Licence at:
 *
 * https://joinup.ec.europa.eu/software/page/eupl5
 *
 * Unless required by applicable law or agreed to in
   writing, software distributed under the Licence is
   distributed on an "AS IS" basis,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
   express or implied.
 * See the Licence for the specific language governing
  permissions and limitations under the Licence.
*/

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

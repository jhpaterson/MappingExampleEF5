using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace MappingExample
{
    public class CompanyContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // define some mappings for Address class using Fluent API
            modelBuilder.Entity<Address>().ToTable("Locations");   // change table name

            modelBuilder.Entity<Address>()
                .HasKey(a => new { a.AddressId, a.PostCode });     // set composite primary key

            modelBuilder.Entity<Address>()                         // set column name, size, null
                .Property(a => a.PropertyName)
                .HasColumnName("BuildingName")
                .HasMaxLength(50)
                .IsOptional();

            modelBuilder.Entity<Address>()                         // set column name, not null
                .Property(a => a.PropertyNumber)
                .HasColumnName("BuildingNumber")
                .IsRequired();

            modelBuilder.Entity<Address>()                         // set column not null                   
                .Property(a => a.PostCode)
                .IsRequired();
        }
    }
}

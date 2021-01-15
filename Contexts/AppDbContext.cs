using Assignment.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.API.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Employee>().ToTable("Employees");
            builder.Entity<Employee>().HasKey(p => p.Id);
            builder.Entity<Employee>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Employee>().Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            builder.Entity<Employee>().Property(p => p.LastName).IsRequired().HasMaxLength(50);
            builder.Entity<Employee>().HasMany(p => p.Reviews).WithOne(p => p.Employee).HasForeignKey(p => p.EmployeeId);

            builder.Entity<Employee>().HasData
                (
                    new Employee { Id = 1, FirstName = "John", LastName = "Doe" }
                );

            builder.Entity<Review>().ToTable("Reviews");
            builder.Entity<Review>().HasKey(p => p.Id);
            builder.Entity<Review>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Review>().Property(p => p.Title).IsRequired().HasMaxLength(50);
            builder.Entity<Review>().Property(p => p.Description).IsRequired().HasMaxLength(250);
        }
    }
}

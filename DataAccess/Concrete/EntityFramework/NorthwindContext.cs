using System;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
	public class NorthwindContext : DbContext
	{

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=Northwind;");
        }

        public DbSet<Category> categories { get; set; }                    // Northwind Entity
        public DbSet<Product> products { get; set; }                       // Northwind Entity
        public DbSet<Customer> customers { get; set; }                     // Northwind Entity
        public DbSet<Order> orders { get; set; }                           // Northwind Entity
        public DbSet<OperationClaim> OperationClaims { get; set; }         // My Entity
        public DbSet<User> Users { get; set; }                             // My Entity
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; } // My Entity

    }
}


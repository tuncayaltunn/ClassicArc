using System;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
	public class NorthwindContext : DbContext
	{
		//public NorthwindContext(DbContextOptions options) : base(options)
		//{
		//}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {//User ID=root;Password=myPassword;

            //optionsBuilder.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=Northwind;Pooling=true;min_pool_size=0;max_pool_size=1024;connection_lifetime=0;trusted_connection=True;TrustServerCertificate=True");
            optionsBuilder.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=Northwind;");
            //base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Customer> customers { get; set; }

    }
}


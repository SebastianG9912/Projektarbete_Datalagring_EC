using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerPrivateInfo> CustomersPrivateInfo { get; set; }
        public DbSet<Foodpack> Foodpacks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Restaurant> Resturaunts { get; set; }

        /// <summary>
        /// Ansluter till databsen
        /// </summary>
        /// <param name="optionsBuilder">Ger de val man kan göra för att ansluta till databasen</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(m => Debug.WriteLine(m))
                .UseSqlServer(@"server=(localdb)\MSSQLLocalDB;database=ProjektDatabaser");
        }

        /// <summary>
        /// Sätter krav till specifika properties i databas-tabellerna
        /// </summary>
        /// <param name="modelBuilder">Ger val för att sätta krav på properties</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .HasIndex(r => r.Phone_number)
                .IsUnique();

            modelBuilder.Entity<Restaurant>()
                .HasIndex(r => r.Name)
                .IsUnique();
        }
    }
}

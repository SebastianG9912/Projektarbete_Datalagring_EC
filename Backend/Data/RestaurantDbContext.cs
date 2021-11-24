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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(m => Debug.WriteLine(m))
                .UseSqlServer(@"server=(localdb)\MSSQLLocalDB;database=PojektDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .HasIndex(r => r.Phone_number)
                .IsUnique();

            modelBuilder.Entity<Restaurant>()
                .HasIndex(r => r.Name)
                .IsUnique();
        }

        public static void Seed()
        {
            using var ctx = new RestaurantDbContext();

            var newCustomers = new Customer[]
            {
                new Customer()
                {
                    CustomerPrivateInfo = new CustomerPrivateInfo(){First_Name = "Sebastian", Last_Name = "Gustafsson"}
                },
                new Customer()
                {
                    CustomerPrivateInfo = new CustomerPrivateInfo(){First_Name = "Jakob", Last_Name = "Dennryd"}
                },
                new Customer()
                {
                    CustomerPrivateInfo = new CustomerPrivateInfo(){First_Name = "Klara", Last_Name = "Bergman"}
                }
            };
            ctx.Customers.AddRange(newCustomers);

            var newRestaurants = new Restaurant[]
            {
                new Restaurant(){Name = "NiceFood", Location = "Eldsberga", Phone_number = "0701234567"},
                new Restaurant(){ Name = "GreenCuisine", Location = "Halmstad", Phone_number = "0729876543"}
            };
            ctx.Resturaunts.AddRange(newRestaurants);

            var newFoodPacks = new Foodpack[]
            {
                new Foodpack(){Category = "Beef", Price = 70, Restaurant = newRestaurants[0], Name = "Köttsoppa"},
                new Foodpack(){Category = "Chicken", Price = 50, Restaurant = newRestaurants[1], Name = "Kycklinggryta"}
            };
            ctx.Foodpacks.AddRange(newFoodPacks);

            var newOrders = new Order[]
            {
                new Order{Customer = newCustomers[1], Foodpacks = new List<Foodpack>(){newFoodPacks[0], newFoodPacks[1]}, OrderDateTime = DateTime.Now}
            };
            ctx.Orders.AddRange(newOrders);

            ctx.SaveChanges();
        }
    }
}


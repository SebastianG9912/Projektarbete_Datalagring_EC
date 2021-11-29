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
                .UseSqlServer(@"server=(localdb)\MSSQLLocalDB;database=ProjektDB");
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

        public void Seed()
        {
            var resturaunts = new List<Restaurant>
            {
                new() {Location = "Halmstad", Name = "Noodle house", Phone_number = "12312356"},
                new() {Location = "Halmstad", Name = "Wook huset", Phone_number = "1234556"}
            };
            AddRange(resturaunts);

            var customers = new List<Customer>
           {
               new() {CustomerPrivateInfo = new CustomerPrivateInfo() {First_Name = "Jakob", Last_Name = "Dennryd"}},
               new () {CustomerPrivateInfo = new CustomerPrivateInfo(){First_Name = "Bert", Last_Name = "Karlsson"}}

           };
            AddRange(customers);

            var foodpacks = new List<Foodpack>
           {
               new () {Category = "Beef", Price = 70, Restaurant = resturaunts[0]},
               new () {Category = "Chicken", Price = 70, Restaurant = resturaunts[1]},
               new () { Category = "Beef", Price = 70, Restaurant = resturaunts[1]},
               new () { Category = "Chicken", Price = 70, Restaurant = resturaunts[0] },
           };
            AddRange(foodpacks);


            var orders = new List<Order>
           {
               new () {Customer = customers[1],
                   Foodpacks = new List<Foodpack>(){foodpacks[0],
                       foodpacks[1]},OrderDateTime = DateTime.Now}
           };

            AddRange(orders);

        }
        public void SeedTest()
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
                new Foodpack(){Category = "Beef", Price = 70, Restaurant = newRestaurants[0]},
                new Foodpack(){Category = "Chicken", Price = 50, Restaurant = newRestaurants[1]},
                new Foodpack(){Category = "Beef", Price = 70, Restaurant = newRestaurants[0]},
                new Foodpack(){Category = "Chicken", Price = 50, Restaurant = newRestaurants[1]},
                new Foodpack(){Category = "Beef", Price = 70, Restaurant = newRestaurants[0]},
                new Foodpack(){Category = "Chicken", Price = 50, Restaurant = newRestaurants[1]}
            };
            ctx.Foodpacks.AddRange(newFoodPacks);

            var newOrders = new Order[]
            {
                new Order{Customer = newCustomers[1],
                    Foodpacks = new List<Foodpack>(){newFoodPacks[0], newFoodPacks[1]}, 
                    OrderDateTime = DateTime.Now}
            };
            ctx.Orders.AddRange(newOrders);

            ctx.SaveChanges();

        }
    }
}


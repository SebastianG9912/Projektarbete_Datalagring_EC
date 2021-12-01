using System.Diagnostics;
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
                .UseSqlServer(@"server=(localdb)\MSSQLLocalDB;database=ProjektDB");
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

        public void Seed()
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

            var customers = new List<Customer>
           {
               new Customer()
               {
                   CustomerPrivateInfo = new CustomerPrivateInfo(){
                       First_Name = "Sebastian",
                       Last_Name = "Gustafsson",
                       UserEmail = "Sebbe@gmail.com",
                       UserPassword = "1234"

                   }
               },
               new Customer()
               {
                   CustomerPrivateInfo = new CustomerPrivateInfo()
                   {
                       First_Name = "Jakob",
                       Last_Name = "Dennryd",
                       UserEmail = "Jakob@gmail.com",
                       UserPassword = "2345"
                   }
               },
               new Customer()
               {
                   CustomerPrivateInfo = new CustomerPrivateInfo()
                   {
                       First_Name = "Klara",
                       Last_Name = "Bergman",
                       UserEmail = "Klara@gmail.com",
                       UserPassword = "3456"
                   }
               }
           };
            AddRange(customers);

            var newFoodPacks = new Foodpack[]
            {
                new Foodpack(){Category = "Beef", Price = 70, Restaurant = newRestaurants[0], Name = "Beef Pie"},
                new Foodpack(){Category = "Vego", Price = 70, Restaurant = newRestaurants[0], Name = "Vegetable Pie"},
                new Foodpack(){Category = "Chicken", Price = 50, Restaurant = newRestaurants[1], Name = "ChickenBurger"},
                new Foodpack(){Category = "Beef", Price = 50, Restaurant = newRestaurants[1], Name = "ClassicBurger"}
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


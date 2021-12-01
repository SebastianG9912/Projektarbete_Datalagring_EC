using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Backend.Data
{
    public class AdminBackend
    {
        /// <summary>
        /// Tar först bort och skapar sedan database. Kan användas för att "reseta" databasen
        /// </summary>
        public static void InitializeDatabase()
        {
            using var ctx = new RestaurantDbContext();

            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
        }

        /// <summary>
        /// Tillåter en admin att logga in
        /// </summary>
        /// <param name="username">Adminkontots användarnamn</param>
        /// <param name="password">Adminkontots lösenord</param>
        /// <returns>True om adminen skrev in rätt användarnamn och lösenord, False om antingen användarnamn eller lösenord är fel</returns>
        public static bool LogIn(string username, string password)
        {
            //Ignorerar om man använder stora eller små bokstäver vid inloggning TODO Ändra till att vara case sensitive?
            //Sätter användarnamn och lösenord till att statiskt vara "admin" och "password"
            if (username.Equals("admin", StringComparison.OrdinalIgnoreCase) && password.Equals("password", StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        /// <summary>
        /// Skapar en query till databasen och hämtar alla kunder
        /// </summary>
        /// <returns>En lista innehållandes alla Customer-objekt i databasen</returns>
        public static List<Customer> GetAllCustomers()
        {
            using var ctx = new RestaurantDbContext();

            return ctx.Customers
                .Include(c => c.CustomerPrivateInfo)
                .ToList();
        }

        /// <summary>
        /// Skapar en query till databasen och hämtar alla restauranger
        /// </summary>
        /// <returns>En lista innehållandes alla Restaurant-objekt i databasen</returns>
        public static List<Restaurant> GetAllRestaurants()
        {
            using var ctx = new RestaurantDbContext();

            return ctx.Resturaunts
                .Include(r => r.Foodpacks)
                .ToList();
        }

        /// <summary>
        /// Lägger till en ny restaurang i databasen
        /// </summary>
        /// <param name="name">Namnet på den nya restaurangen</param>
        /// <param name="location">Platsen för den nya restaurangen</param>
        /// <param name="phoneNumber">Telefonnummret för den nya restaurangen</param>
        /// <returns></returns>
        public static bool AddNewRestaurant(string name, string location, string phoneNumber)
        {
            if (name == null || location == null || phoneNumber == null ||
                name == "" || location == "" || phoneNumber == "")
                return false;

                using var ctx = new RestaurantDbContext();

            var exists = ctx.Resturaunts.FirstOrDefault(r => r.Name == name || r.Phone_number == phoneNumber);
            if (exists != null)//Om objekt med namn "name" eller telefonnummer "phoneNumber" finns, returnera false
                return false;

            ctx.Resturaunts.Add(new Restaurant()
            {
                Name = name,
                Location = location,
                Phone_number = phoneNumber
            });
            ctx.SaveChanges();
            return true;
        }

        /// <summary>
        /// Seedar databsen med data i testsyfte
        /// </summary>
        public static void Seed()
        {
            using var ctx = new RestaurantDbContext();

            var newCustomers = new List<Customer>
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
            ctx.Customers.AddRange(newCustomers);

            var newRestaurants = new Restaurant[]
            {
                new Restaurant(){Name = "NiceFood", Location = "Eldsberga", Phone_number = "0701234567"},
                new Restaurant(){ Name = "GreenCuisine", Location = "Halmstad", Phone_number = "0729876543"}
            };
            ctx.Resturaunts.AddRange(newRestaurants);

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

        //TODO ta bort den här metoden
        /// <summary>
        /// Den gamla seed-metoden som kraschar programmet
        /// </summary>
        public static void OldBrokenSeed()
        {
            using var ctx = new RestaurantDbContext();

            var resturaunts = new List<Restaurant>
            {
                new() {Location = "Halmstad", Name = "Noodle house", Phone_number = "12312356"},
                new() {Location = "Halmstad", Name = "Wook huset", Phone_number = "1234556"}
            };
            ctx.Resturaunts.AddRange(resturaunts);

            var customers = new List<Customer>
            {
                new() {CustomerPrivateInfo = new CustomerPrivateInfo() {First_Name = "Jakob", Last_Name = "Dennryd"}},
                new () {CustomerPrivateInfo = new CustomerPrivateInfo(){First_Name = "Bert", Last_Name = "Karlsson"}}

            };
            ctx.Customers.AddRange(customers);

            var foodpacks = new List<Foodpack>
            {
                new () {Category = "Beef", Price = 70, Restaurant = resturaunts[0]},
                new () {Category = "Chicken", Price = 70, Restaurant = resturaunts[1]},
                new () { Category = "Beef", Price = 70, Restaurant = resturaunts[1]},
                new () { Category = "Chicken", Price = 70, Restaurant = resturaunts[0] },
            };
            ctx.Foodpacks.AddRange(foodpacks);


            var orders = new List<Order>
            {
                new () {Customer = customers[1], Foodpacks = new List<Foodpack>(){foodpacks[0], foodpacks[1]},OrderDateTime = DateTime.Now}
            };

            ctx.Orders.AddRange(orders);

            ctx.SaveChanges();
        }
    }
}

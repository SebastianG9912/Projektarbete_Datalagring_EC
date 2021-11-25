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
        public static void InitializeDatabase()
        {
            using var ctx = new RestaurantDbContext();

            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
        }

        public static bool LogIn(string username, string password)
        {
            //Ignorerar om man använder stora eller små bokstäver vid inloggning TODO Ändra till att vara case sensitive?
            //Sätter användarnamn och lösenord till att statiskt vara "admin" och "password"
            if (username.Equals("admin", StringComparison.OrdinalIgnoreCase) && password.Equals("password", StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        public static List<Customer> GetAllCustomers()
        {
            using var ctx = new RestaurantDbContext();

            return ctx.Customers
                .Include(c => c.CustomerPrivateInfo)
                .ToList();
        }

        public static List<Restaurant> GetAllRestaurants()
        {
            using var ctx = new RestaurantDbContext();

            return ctx.Resturaunts
                .Include(r => r.Foodpacks)
                .ToList();
        }

        public static bool AddNewRestaurant(string name, string location, string phoneNumber)
        {
            //TODO lägg till case där den här metoden returnerar false
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
                new Foodpack(){Category = "Beef", Price = 70, Restaurant = newRestaurants[0]},
                new Foodpack(){Category = "Chicken", Price = 50, Restaurant = newRestaurants[1]}
            };
            ctx.Foodpacks.AddRange(newFoodPacks);

            var newOrders = new Order[]
            {
                new Order{Customer = newCustomers[1], Foodpacks = new List<Foodpack>(){newFoodPacks[0], newFoodPacks[1]}, OrderDateTime = DateTime.Now}
            };
            ctx.Orders.AddRange(newOrders);

            ctx.SaveChanges();
        }

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

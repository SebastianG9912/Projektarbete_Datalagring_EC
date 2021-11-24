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
            throw new NotImplementedException();
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
            };
            ctx.Foodpacks.AddRange(newFoodPacks);

            var newOrders = new Order[]
            {
                new Order{Customer = newCustomers[1], Foodpacks = new List<Foodpack>(){newFoodPacks[0]}, OrderDateTime = DateTime.Now}
            };
            ctx.Orders.AddRange(newOrders);

            ctx.SaveChanges();
        }
    }
}

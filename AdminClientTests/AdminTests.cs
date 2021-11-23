using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Backend.Data;
using Backend.Model;

namespace Tests
{
    public class AdminTests
    {
        [Fact]
        public void ResetDatabaseTest()
        {
            AdminBackend.InitializeDatabase();
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

            Assert.Equal(3, ctx.Customers.Count());
            Assert.Equal(2, ctx.Resturaunts.Count());
            Assert.Single(ctx.Foodpacks);
            Assert.Single(ctx.Orders);

            AdminBackend.InitializeDatabase();

            Assert.Empty(ctx.Customers);
            Assert.Empty(ctx.Resturaunts);
            Assert.Empty(ctx.Foodpacks);
            Assert.Empty(ctx.Orders);
        }
    }
}
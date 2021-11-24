using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Backend.Data;
using Backend.Model;

namespace BackendTests
{
    public class AdminTests
    {
        public AdminTests()
        {
            AdminBackend.InitializeDatabase();
            AdminBackend.Seed();
        }

        [Fact]
        public void ResetDatabaseTest()
        {
            using var ctx = new RestaurantDbContext();
            Assert.Equal(3, ctx.Customers.Count());
            Assert.Equal(2, ctx.Resturaunts.Count());
            Assert.Single(ctx.Foodpacks);
            Assert.Single(ctx.Orders);

            AdminBackend.InitializeDatabase();//För reset

            Assert.Empty(ctx.Customers);
            Assert.Empty(ctx.Resturaunts);
            Assert.Empty(ctx.Foodpacks);
            Assert.Empty(ctx.Orders);
        }

        [Fact]
        public void ViewAllCustomersTest()
        {
            List<Customer> customerList = AdminBackend.GetAllCustomers();
            string[] names = new[] {"Sebastian", "Jakob", "Klara"};

            for (int i = 0; i < names.Length; i++)
                Assert.Equal(names[i], customerList.ElementAt(i).CustomerPrivateInfo.First_Name);
            //TODO Lägg till assert för customerList.count == 3
            
        }

        [Fact]
        public void ViewAllRestaurantsTest()
        {
            List<Restaurant> restList = AdminBackend.GetAllRestaurants();
            string[] names = new[] {"NiceFood", "GreenCuisine"};

            Assert.Equal(2, restList.Count);
            for (int i = 0; i < names.Length; i++)
                Assert.Equal(names[i], restList.ElementAt(i).Name);
        }

        [Fact]
        public void AddRestaurantTest()
        {
            AdminBackend.InitializeDatabase();//För att ta resetta databasen utan seeding
            using var ctx = new RestaurantDbContext();
            
            Assert.Empty(ctx.Resturaunts);

            Assert.True(AdminBackend.AddNewRestaurant("NiceFood", "Halmstad", "0723492817"));
            Assert.Single(ctx.Resturaunts);
            Assert.Equal("NiceFood", ctx.Resturaunts.FirstOrDefault().Name);
        }
    }
}

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
            Assert.Equal(2, ctx.Foodpacks.Count());
            Assert.Equal(1, ctx.Orders.Count());

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

            Assert.Equal("Sebastian", customerList.ElementAt(0).CustomerPrivateInfo.First_Name);
            Assert.Equal(names.Length, customerList.Count);
            
        }

        [Fact]
        public void ViewAllRestaurantsTest()
        {
            List<Restaurant> restList = AdminBackend.GetAllRestaurants();
            string[] names = new[] { "NiceFood", "GreenCuisine" };

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






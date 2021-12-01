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
        /// <summary>
        /// Resetar databsen och fyller den med testdata
        /// </summary>
        public AdminTests()
        {
            AdminBackend.InitializeDatabase();
            AdminBackend.Seed();
        }

        [Fact]
        public void ResetDatabaseTest()//Testar om databasen resetar sig själv korrekt
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
        public void ViewAllCustomersTest()//Testar om metoden "GetAllCustomers" fungerar korrekt
        {
            List<Customer> customerList = AdminBackend.GetAllCustomers();
            string[] names = new[] {"Sebastian", "Jakob", "Klara"};

            for (int i = 0; i < names.Length; i++)
                Assert.Equal(names[i], customerList.ElementAt(i).CustomerPrivateInfo.First_Name);

            Assert.Equal("Sebastian", customerList.ElementAt(0).CustomerPrivateInfo.First_Name);
            Assert.Equal(names.Length, customerList.Count);
            
        }

        [Fact]
        public void ViewAllRestaurantsTest()//Testar om metoden "GetAllRestaurants" fungerar korrekt
        {
            List<Restaurant> restList = AdminBackend.GetAllRestaurants();
            string[] names = new[] { "NiceFood", "GreenCuisine" };

            Assert.Equal(2, restList.Count);
            for (int i = 0; i < names.Length; i++)
                Assert.Equal(names[i], restList.ElementAt(i).Name);
        }

        [Fact]
        public void AddRestaurantTest()//Testar om metoden "AddNewRestaurant" fungerar korrekt
        {
            AdminBackend.InitializeDatabase();//För att ta resetta databasen utan seeding
            using var ctx = new RestaurantDbContext();
            
            Assert.Empty(ctx.Resturaunts);

            //När man kan lägga till ny restaurang
            Assert.True(AdminBackend.AddNewRestaurant("NiceFood", "Halmstad", "07298765432"));
            Assert.Single(ctx.Resturaunts);
            Assert.Equal("NiceFood", ctx.Resturaunts.FirstOrDefault().Name);
            //När man inte kan lägga till restaurang (upptaget namn/telefonnummer)
            Assert.False(AdminBackend.AddNewRestaurant("NiceFood", "Göteborg", "0723456789"));//Namn upptaget
            Assert.False(AdminBackend.AddNewRestaurant("Grenholmen", "Göteborg", "07298765432"));//Telefonnummer upptaget
            Assert.False(AdminBackend.AddNewRestaurant("NiceFood", "Göteborg", "07298765432"));//Namn och telefonnummer upptaget
            //Ska inte kunna lägga till tomma uppgifter
            /* Enligt:
             * 000
             * 001
             * 010
             * 011
             * 100
             * 101
             * 110
             */
            Assert.False(AdminBackend.AddNewRestaurant("", "", ""));
            Assert.False(AdminBackend.AddNewRestaurant("", "", "0723456789"));
            Assert.False(AdminBackend.AddNewRestaurant("", "Göteborg", ""));
            Assert.False(AdminBackend.AddNewRestaurant("", "Göteborg", "0723456789"));
            Assert.False(AdminBackend.AddNewRestaurant("Grenholmen", "", ""));
            Assert.False(AdminBackend.AddNewRestaurant("Grenholmen", "", "0723456789"));
            Assert.False(AdminBackend.AddNewRestaurant("Grenholmen", "Göteborg", ""));

            
        }
    }
}






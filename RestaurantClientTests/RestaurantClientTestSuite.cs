using System.Collections.Generic;
using System.Linq;
using Backend.Data;
using Backend.Model;
using Xunit;

namespace RestaurantClientTests
{
    public class RestaurantClientTestSuite
    {
        [Fact]
        public void AddFoodBoxTest()
        {
            //TODO fixa efter vi mergat
            //AdminBackend.InitializeDatabase();
            //AdminBackend.Seed();

            var ctx = new RestaurantClient();

            Assert.True(ctx.AddFoodbox(1, "Beef", 45, "CheeseBurger"));
        }

        [Fact]
        public void SeeSoldMealsTest()
        {
            //TODO fixa efter vi mergat
            //AdminBackend.InitializeDatabase();
            //AdminBackend.Seed();

            List<Foodpack> list = RestaurantClient.SoldFoodboxes(1);
            string[] names = { "Beef Pie", "Vegetable Pie" };

            for (var i = 0; i < names.Length; i++)
                Assert.Equal(names[i], list.ElementAt(i).Name);
        }

        [Fact]
        public void SeeUnsoldMealsTest()
        {
            //TODO fixa efter vi mergat
            //AdminBackend.InitializeDatabase();
            //Seed();

            List<Foodpack> list = RestaurantClient.UnsoldFoodboxes(2);
            string[] names = { "ChickenBurger", "ClassicBurger" };

            for (var i = 0; i < names.Length; i++)
                Assert.Equal(names[i], list.ElementAt(i).Name);
        }
    }
}
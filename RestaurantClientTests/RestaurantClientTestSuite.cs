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
            //Seed();

            var ctx = new RestaurantClient();

            Assert.True(ctx.AddFoodbox(1, "Beef", 45, "CheeseBurger"));
        }

        [Fact]
        public void SeeSoldMealsTest()
        {
            //TODO fixa efter vi mergat
            //AdminBackend.InitializeDatabase();
            //Seed();

            List<Foodpack> list = RestaurantClient.SoldFoodboxes(1);
            string[] names = new[] { "Beef Pie", "Vegetable Pie" };

            Assert.Equal(2, list.Count);
            for (int i = 0; i < names.Length; i++)
                Assert.Equal(names[i], list.ElementAt(i).Name);
        }

        [Fact]
        public void SeeUnsoldMealsTest()
        {
            //TODO fixa efter vi mergat
            //AdminBackend.InitializeDatabase();
            //Seed();

            List<Foodpack> list = RestaurantClient.UnsoldFoodboxes(2);
            string[] names = new[] { "ChickenBurger", "ClassicBurger" };

            Assert.Equal(2, list.Count);
            for (int i = 0; i < names.Length; i++)
                Assert.Equal(names[i], list.ElementAt(i).Name);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Backend.Data;
using Backend.Model;
using Xunit;

namespace RestaurantClientTests
{
    public class RestaurantClientTestSuite
    {
        public RestaurantClientTestSuite()
        {
            AdminBackend.InitializeDatabase();
            AdminBackend.Seed();
        }

        [Fact]
        public void AddFoodBoxTest()
        {
            var ctx = new RestaurantClient();
            // rest Id 1 och 2 finns.

            Assert.True(ctx.AddFoodbox(1, "Beef", 45, "CheeseBurger"));
            Assert.False(ctx.AddFoodbox(3, "Beef", 40, "CheeseBurger"));
        }

        [Fact]
        public void SeeSoldMealsTest()
        {
            List<Foodpack> list = RestaurantClient.SoldFoodboxes(1);
            string[] names = { "Beef Pie", "Vegetable Pie" };

            Assert.NotEmpty(list);

            for (int i = 0; i < names.Length; i++)
                Assert.Equal(names[i], list.ElementAt(i).Name);
        }

        [Fact]
        public void SeeUnsoldMealsTest()
        {
            List<Foodpack> list = RestaurantClient.UnsoldFoodboxes(2);
            string[] names = { "ChickenBurger", "ClassicBurger" };

            Assert.NotEmpty(list);

            for (var i = 0; i < names.Length; i++)
                Assert.Equal(names[i], list.ElementAt(i).Name);
        }
    }
}
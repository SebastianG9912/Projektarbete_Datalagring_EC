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
            var ctx = new RestaurantClient();

            Assert.True(ctx.AddFoodbox(1, "Beef", 45, "K�ttsoppa"));
        }

        [Fact]
        public void SeeSoldMealsTest()
        {
            List<Foodpack> list = RestaurantClient.SoldFoodboxes(1);
            string[] names = new[] { "K�ttsoppa", "Gr�nsakssoppa" };

            Assert.Equal(2, list.Count);
            for (int i = 0; i < names.Length; i++)
                Assert.Equal(names[i], list.ElementAt(i).Name);
        }

        [Fact]
        public void SeeUnsoldMealsTest()
        {
            List<Foodpack> list = RestaurantClient.UnsoldFoodboxes(2);
            string[] names = new[] { "Kycklinggryta", "K�ttgryta" };

            Assert.Equal(2, list.Count);
            for (int i = 0; i < names.Length; i++)
                Assert.Equal(names[i], list.ElementAt(i).Name);
        }
    }
}
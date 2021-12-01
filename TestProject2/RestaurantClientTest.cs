using Backend.Data;
using Xunit;


namespace TestProject2
{
    public class RestaurantClientTest
    {
        [Fact]
        public void AddFoodBoxTest()
        {
            var ctx = new RestaurantClient();

            Assert.True(ctx.AddFoodbox(1, "Beef", 45));
        }
    }
}
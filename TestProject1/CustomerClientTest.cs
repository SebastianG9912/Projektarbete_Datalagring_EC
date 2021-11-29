using System;
using System.Collections.Generic;
using Xunit;
using Backend;
using Backend.Clients;
using Backend.Data;
using Backend.Model;

namespace TestProject1
{
    public class CustomerClientTest
    {
        public CustomerClientTest()
        {
            using var ctx = new RestaurantDbContext();
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            ctx.SeedTest();
            
        }
        [Fact]
        public void TestPurchase()
        {
            var client = new CustomerClient();
            client.PurchaseFoodpack(new List<int>(){3}, 1);
            Assert.True(client.PurchasedFoodpacks(1).Find(f => f.Id == 2) != null);

        }
    }
}
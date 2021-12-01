using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Backend;
using Backend.Clients;
using Backend.Data;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace TestProject1
{
    public class CustomerClientTest
    {
        public CustomerClientTest()
        {
            AdminBackend.InitializeDatabase();
            AdminBackend.Seed();
        }
        [Fact]
        public void TestPurchase()
        {
            using var ctx = new RestaurantDbContext();
            var client = new CustomerClient();
            client.PurchaseFoodpack(new List<int>(){3}, 1);

            var query = ctx.Orders.Include(o => o.Customer)
                .Include(o => o.Foodpacks)
                .Where(o => o.Customer.Id == 1 && o.Foodpacks.Contains(new Foodpack()
                {
                    Id = 3,
                    Category = "Beef",
                    Price = 70,
                    Restaurant = new Restaurant()
                    {
                        Name = "NiceFood", Location = "Eldsberga", Phone_number = "0701234567"
                    }
                }));
            var order = query.FirstOrDefault();
            Assert.NotNull(order);
        }
    }
}
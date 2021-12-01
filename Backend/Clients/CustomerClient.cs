using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Clients
{
    
    public class CustomerClient
    {
        public void SeedDatabase()
        {
            AdminBackend.InitializeDatabase();
            AdminBackend.Seed();
        }
        //List of all foodpacks up for sale
        public List<Foodpack> FoodpacksForSale(string category)
        {
            using var ctx = new RestaurantDbContext();

            var query = ctx.Foodpacks
                .Include(f => f.Order)
                .Include(f => f.Restaurant)
                .Where(f => f.Order == null && f.Category == category).OrderByDescending(f => f.Price).ToList();

            return query;
        }

        // Purchase foodpacks with the ID's given in the foodpackID list for the Customer with the given ID.
        public Order PurchaseFoodpack(List<int> foodpackID, int customerID)
        {
            var ctx =new RestaurantDbContext();
            List<Foodpack> foodpackCart = new List<Foodpack>();
            foreach (var fp in foodpackID)
            {
                var queryFoodpack = ctx.Foodpacks
                    .Include(f => f.Restaurant)
                    .Where(f => f.Id == fp).FirstOrDefault();
                foodpackCart.Add(queryFoodpack);
            }
            

            var queryCustomer = ctx.Customers
                .Include(c => c.CustomerPrivateInfo)
                .Where(c => c.Id == customerID).FirstOrDefault();


            var order = new Order()
            {
                Customer = queryCustomer,
                Foodpacks = foodpackCart,
                OrderDateTime = DateTime.Now

            };

            ctx.Add(order);
            ctx.SaveChanges();

            return order;
        }
        // Returns all the purchased foodpacks with orders connected to the given customer ID
        public List<Foodpack> PurchasedFoodpacks(int customerID)
        {
            var ctx = new RestaurantDbContext();

            var query = ctx.Foodpacks
                .Include(f => f.Order)
                .ThenInclude(o => o.Customer)
                .Include(f => f.Restaurant)
                .Where(f => f.Order.Customer.Id == customerID).ToList();

            return query;
        }
    }
}

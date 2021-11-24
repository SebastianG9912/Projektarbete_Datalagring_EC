using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class RestaurantClient
    {
        public List<Foodpack> SoldFoodboxes(int restID)
        {
            var ctx = new RestaurantDbContext();

            var query = ctx.Foodpacks
                .Include(f => f.Order)
                .Where(f => f.Restaurant.Id == restID && f.Order != null)
                .ToList();

            return query;
        }

        public List<Foodpack> UnsoldFoodboxes(int restID)
        {
            var ctx = new RestaurantDbContext();

            var query = ctx.Foodpacks
                .Include(f => f.Order)
                .Where(f => f.Restaurant.Id == restID && f.Order == null)
                .ToList();

            return query;
        }

        public bool AddFoodbox(int restId, string mealCategory, int unitPrice)
        {
            using var ctx = new RestaurantDbContext();

            var box = new Foodpack() { Category = mealCategory, Price = unitPrice, Restaurant = ctx.Resturaunts.Find(restId) };

            ctx.Foodpacks.Add(box);
            ctx.SaveChanges();

            return true;
        }

    }
}

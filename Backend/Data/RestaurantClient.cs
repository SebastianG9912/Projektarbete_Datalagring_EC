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
                .Where(r => r.Restaurant.Id == restID)
                .Include(r => r.Restaurant)
                .ToList();

            return query;
        }

        public List<Foodpack> OrderedFoodboxes(int restID)
        {
            var ctx = new RestaurantDbContext();

            var query = ctx.Foodpacks
                .Where(f => f.Restaurant.Id == restID)
                .Include(f => f.Order)
                .ToList();

            return query;
        }

        public Foodpack AddFoodbox(int id, string mealCategory, int unitPrice)
        {
            using var ctx = new RestaurantDbContext();

            var box = new Foodpack() { Category = mealCategory, Price = unitPrice, Restaurant = ctx.Resturaunts.Find(id) };

            ctx.Foodpacks.Add(box);
            ctx.SaveChanges();

            return box;
        }
    }
}

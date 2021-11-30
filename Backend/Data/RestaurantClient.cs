using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class RestaurantClient
    {
        public static List<Foodpack> SoldFoodboxes(int restID)
        {
            var ctx = new RestaurantDbContext();

            var query = ctx.Foodpacks
                .Include(f => f.Order)
                .Where(f => f.Restaurant.Id == restID && f.Order != null)
                .ToList();

            return query;
        }

        public static List<Foodpack> UnsoldFoodboxes(int restID)
        {
            var ctx = new RestaurantDbContext();

            var query = ctx.Foodpacks
                .Include(f => f.Order)
                .Where(f => f.Restaurant.Id == restID && f.Order == null)
                .ToList();

            return query;
        }

        public bool AddFoodbox(int restId, string mealCategory, int unitPrice, string name)
        {
            using var ctx = new RestaurantDbContext();

            var box = new Foodpack() { Category = mealCategory, Price = unitPrice, Restaurant = ctx.Resturaunts.Find(restId), Name = name};

            ctx.Foodpacks.Add(box);
            ctx.SaveChanges();

            return true;
        }

    }
}

// See https://aka.ms/new-console-template for more information
using Backend.Data;

RestaurantDbContext ctx = new RestaurantDbContext();
ctx.Database.EnsureDeleted();
ctx.Database.EnsureCreated();
ctx.Seed();
Console.WriteLine("Deletede, Created, Seeded");


RestaurantClient.OrderedFoodboxes(1);
RestaurantClient.SoldFoodboxes(1);
RestaurantClient.AddFoodbox(1, "Beef", 45);

Console.ReadKey();
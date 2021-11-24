// See https://aka.ms/new-console-template for more information
using Backend.Data;

RestaurantDbContext ctx = new RestaurantDbContext();
ctx.Database.EnsureDeleted();
ctx.Database.EnsureCreated();
ctx.Seed();
Console.WriteLine("Deleted, Created, Seeded");

var RestaurantClient = new RestaurantClient();

//RestaurantClient.AddFoodbox(1, "Beef", 45);
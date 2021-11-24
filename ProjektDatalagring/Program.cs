﻿// See https://aka.ms/new-console-template for more information
using Backend.Data;

RestaurantDbContext ctx = new RestaurantDbContext();
ctx.Database.EnsureDeleted();
ctx.Database.EnsureCreated();
RestaurantDbContext.Seed();

while (true)
{
    Console.WriteLine("RestaurantClient Menu");
    Console.WriteLine("1 See unsold foodpacks");
    Console.WriteLine("2 See sold foodpacks");
    Console.WriteLine("3 Add foodpack");

    var input = Console.ReadLine();

    if (input == "1")
    {

        Console.WriteLine("Enter id");

        var choice = Convert.ToInt32(Console.ReadLine());

        foreach (var box in RestaurantClient.UnsoldFoodboxes(choice))
        {
            Console.WriteLine($"Pack ID: {box.Id}, " +
                              $"Pack Category: {box.Category}" +
                              $"Pack Name: {box.Name}");
        }

        Console.ReadLine();
    }

    if (input == "2")
    {

        Console.WriteLine("Enter id");

        var choice = Convert.ToInt32(Console.ReadLine());

        foreach (var box in RestaurantClient.SoldFoodboxes(choice))
        {
            Console.WriteLine($"Pack ID: {box.Id}, " +
                              $"Pack Name: {box.Name}" +
                              $"Pack Category: {box.Category}, " +
                              $"Order ID: {box.Order.Id}, " +
                              $"Pack Price: {box.Price} SEK");
        }

        Console.ReadLine();
    }

    if (input == "3")
    {
        Console.WriteLine("Enter id, category, price");
        var input1 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var id = Convert.ToInt32(input1[0]);
        var category = input1[1];
        var price = Convert.ToInt32(input1[2]);
        var name = input1[3];

        var RestaurantClient = new RestaurantClient();

        RestaurantClient.AddFoodbox(id, category, price, name);
    }

    else
    {
        Console.WriteLine("Error input, try again");
    }

  


    
}

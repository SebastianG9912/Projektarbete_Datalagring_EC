using Backend.Data;


while (true)
{
    Console.WriteLine("RestaurantClient Menu");
    Console.WriteLine("---------------------\n");
    Console.WriteLine("1 See unsold foodpacks");
    Console.WriteLine("2 See sold foodpacks");
    Console.WriteLine("3 Add foodpack");
    Console.WriteLine("4 Reset Database\n");

    Console.WriteLine("Input choice\n");
    var input = Console.ReadLine();

    if (input == "1")
    {
        Console.Clear();
        Console.WriteLine("Enter Restaurant ID");
        // ID 2 har osålda

        try
        {
            var choice = Convert.ToInt32(Console.ReadLine());
            foreach (var box in RestaurantClient.UnsoldFoodboxes(choice))
            {
                Console.WriteLine($"Pack ID: {box.Id}, " +
                                  $"Category: {box.Category}, " +
                                  $"Name: {box.Name}");
            }

            if (RestaurantClient.UnsoldFoodboxes(choice).Count == 0)
            {
                Console.WriteLine("This restaurant has no unsold Foodpacks\nPress enter to get back to main menu");
            }

        }
        catch
        {
            Console.WriteLine("Input format not correct, please enter a number");
        }

        Console.ReadKey();
    }

    if (input == "2")
    {
        Console.Clear();
        Console.WriteLine("Enter Restaurant ID");

        // ID 1 har sålda

        try
        {
            var choice = Convert.ToInt32(Console.ReadLine());

            foreach (var box in RestaurantClient.SoldFoodboxes(choice))
            {
                Console.WriteLine($"Pack ID: {box.Id}, " +
                                  $"Name: {box.Name}, " +
                                  $"Category: {box.Category}, " +
                                  $"Order ID: {box.Order.Id}, " +
                                  $"Price: {box.Price} SEK");
            }

            if (RestaurantClient.SoldFoodboxes(choice).Count == 0)
            {
                Console.WriteLine("This restaurant has no sold Foodpacks\nPress enter to get back to main menu");
            }
        }
        catch
        {
            Console.WriteLine("Input format not correct, please enter a number");
        }

        Console.ReadKey();
    }

    if (input == "3")
    {
        Console.Clear();
        Console.WriteLine("Insert restaurant ID");
        int Id = (Convert.ToInt32(Console.ReadLine()));
        Console.WriteLine("Insert meal name");
        string name = Console.ReadLine();
        Console.WriteLine("Insert price");
        int price = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Insert meal category beef/vego/fish/chicken");
        string category = Console.ReadLine().ToLower();

        if (category == "beef" || category == "vego" || category == "fish" || category == "chicken")
        {
            var restaurantClient = new RestaurantClient();

            bool wrongRestId = restaurantClient.AddFoodbox(Id, name, price, category);

            if (!wrongRestId)
            {
                Console.Clear();
                Console.WriteLine("Restaurant does not exist!\n" +
                                  "Please enter an existing Restaurant Id");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Your Foodpack has been added " +
                                  $"to your restaurant: {Id}!");
            }

            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Wrong category input, please input correct category");
            Console.ReadKey();
        }
        
    }

    if (input == "4")
    {
        AdminBackend.InitializeDatabase();
        AdminBackend.Seed();
        Console.Clear();
    }

    else
    {
        Console.Clear();
        Console.WriteLine("Error input, try again");
        Console.Clear();
        Console.ReadKey();
    }
}

using Backend.Clients;
using Backend.Model;

LoginManager loginManager = new LoginManager();
while (true)
{
    Console.Clear();
    Console.WriteLine("Welcome to the Customer Client," +
                      " to log in please enter your email and password below!");
    string input = Console.ReadLine();
    string[] emailAndPassword = input.Split(' ');

    string email = emailAndPassword[0];
    string password = emailAndPassword[1];

    bool quit = false;
    var customer = loginManager.Login(email, password);
    if (customer != null)
    {
        CustomerClient customerClient = new CustomerClient();
        

        while (quit == false)
        {

            Console.Clear();
            Console.WriteLine("Welcome!");
            Console.WriteLine();
            Console.WriteLine("1. List all foodpacks currently for sale.");
            Console.WriteLine("2. Make a new order.(Also lists foodpacks for sale)");
            Console.WriteLine("3. See all your previously ordered foodpacks.");
            Console.WriteLine("4. Seed the database.(For testing purposes)");
            Console.WriteLine("5. Exit the app");
            var keyInfo = Console.ReadKey();
            int choice = int.Parse(keyInfo.KeyChar.ToString());

            switch (choice)
            {
                case 1:
                {
                    Console.Clear();
                    Console.WriteLine("Id | Category | Price | Restaurant");
                    List<Foodpack> fpList = customerClient.FoodpacksForSale();
                    foreach (var fp in fpList)
                    {
                        Console.WriteLine(fp.Id + " | " + fp.Category + " | " + fp.Price + " | " + fp.Restaurant.Name);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Press ENTER to return to selection");
                    Console.ReadLine();

                    break;
                }
                case 2:
                {
                    Console.Clear();
                    Console.WriteLine("Id | Category | Price | Restaurant");
                    List<Foodpack> fpList = customerClient.FoodpacksForSale();
                    foreach (var fp in fpList)
                    {
                        Console.WriteLine(fp.Id + " | " + fp.Category + " | " + fp.Price + " | " + fp.Restaurant.Name);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Put down the Id's of the foodpacks you want to order below, with a space between each Id (eg. 1 2 3)");
                    string fpInput = Console.ReadLine();
                    string[] fpArray = fpInput.Split(' ');
                    List<int> fpIdList = new List<int>();
                    foreach (string fp in fpArray)
                    {
                        fpIdList.Add(int.Parse(fp));
                    }
                    
                    var order = customerClient.PurchaseFoodpack(fpIdList, customer.Id);

                    Console.Clear();

                    Console.WriteLine("Order receipt: ");
                    Console.WriteLine();
                    Console.WriteLine("Customer name | Order date | Order id");
                    Console.WriteLine(order.Customer.CustomerPrivateInfo.First_Name
                    + " " + order.Customer.CustomerPrivateInfo.Last_Name
                    + " | " + order.OrderDateTime
                    + " | " + order.Id);
                    Console.WriteLine("Foodpacks in order: ");
                    Console.WriteLine("Id | Category | Price | Restaurant");
                    foreach (var fp in order.Foodpacks)
                    {
                        Console.WriteLine(fp.Id
                        +" | " + fp.Category
                        +" | " + fp.Price
                        +" | " + fp.Restaurant.Name);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Press ENTER to continue");
                    Console.ReadLine();
                    break;
                }
                case 3:
                {
                    Console.Clear();
                    Console.WriteLine("Here are your purchased foodpacks: ");
                    Console.WriteLine();
                    Console.WriteLine("Id | Category | Price | Restaurant");
                    List<Foodpack> fpList = customerClient.PurchasedFoodpacks(customer.Id);
                    foreach (var fp in fpList)
                    {
                        Console.WriteLine(fp.Id + " | " + fp.Category + " | " + fp.Price + " | " + fp.Restaurant.Name);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Press ENTER to return to selection");
                    Console.ReadLine();
                        break;
                }
                case 4:
                {
                    customerClient.SeedDatabase();
                    break;
                }
                case 5:
                {
                    quit = true;
                    break;
                }
                default:
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input, please try again");
                    Console.WriteLine("Press ENTER to continue");
                    Console.ReadLine();
                    break;
                }
            }
        }
    }
       

    else
    {
        Console.WriteLine("The email and/or password given was incorrect! Press ENTER to try again.");
        Console.ReadLine();
    }
}




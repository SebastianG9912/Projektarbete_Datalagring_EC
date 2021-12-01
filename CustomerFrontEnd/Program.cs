using Backend.Clients;
using Backend.Model;

LoginManager loginManager = new LoginManager();
bool loginSucces = false;
string[] emailAndPassword = new string []{};
string email = "";
string password = "";
bool quit = false;
var customer = new CustomerPrivateInfo();
while (true)
{
    while (!loginSucces)
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Customer Client," +
                          " to log in please enter your email and password below!");
        string input = Console.ReadLine();
        emailAndPassword = input.Split(' ');

        if (emailAndPassword[1] == "")
        {
            Console.WriteLine("You did not enter a password, please try again!");

        }
        else
        {
            email = emailAndPassword[0];
            password = emailAndPassword[1];
        }

        customer = loginManager.Login(email, password);

        if (customer == null)
        {
            Console.WriteLine("Wrong email/password, try again!");
        }
        else
        {
            loginSucces = true;
        }
    }
        

    



   
    
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
                    Console.WriteLine("Enter your chosen category: (Beef, Fish, Vego, Chicken)");
                    string inputCategory = Console.ReadLine();
                    if (inputCategory == "Beef" || inputCategory == "Fish" || inputCategory == "Vego" || inputCategory =="Chicken")
                    {
                        Console.Clear();
                        Console.WriteLine("Id | Category | Price | Restaurant");
                        List<Foodpack> fpList = customerClient.FoodpacksForSale(inputCategory);
                        foreach (var fp in fpList)
                        {
                            Console.WriteLine(fp.Id + " | " + fp.Category + " | " + fp.Price + " | " + fp.Restaurant.Name);
                        }

                        Console.WriteLine();
                        Console.WriteLine("Press ENTER to return to selection");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("The given category doesn't exist");
                        Console.Clear();
                        goto case 1;
                    }
                   

                    break;
                }
                case 2:
                {
                    Console.WriteLine("Enter your chosen category: (Beef, Fish, Vego, Chicken)");
                    string inputCategory = Console.ReadLine();
                    if (inputCategory == "Beef" || inputCategory == "Fish" || inputCategory == "Vego" ||
                        inputCategory == "Chicken")
                    {
                        Console.Clear();
                        Console.WriteLine("Id | Category | Price | Restaurant");
                        List<Foodpack> fpList = customerClient.FoodpacksForSale(inputCategory);
                        foreach (var fp in fpList)
                        {
                            Console.WriteLine(fp.Id + " | " + fp.Category + " | " + fp.Price + " | " +
                                              fp.Restaurant.Name);
                        }

                        Console.WriteLine();
                        Console.WriteLine(
                            "Put down the Id's of the foodpacks you want to order below, with a space between each Id (eg. 1 2 3)");
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
                                              + " | " + fp.Category
                                              + " | " + fp.Price
                                              + " | " + fp.Restaurant.Name);
                        }

                        Console.WriteLine();
                        Console.WriteLine("Press ENTER to continue");
                        Console.ReadLine();
                        
                    }

                    else
                    {
                        Console.WriteLine("The given category doesn't exist");
                        Console.Clear();
                        goto case 2;
                    }
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




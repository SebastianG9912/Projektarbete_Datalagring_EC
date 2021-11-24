using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Data;

namespace ConsoleFrontend
{
    public class AdminClient
    {
        public static void Main(string[] args)
        {
            var key = new ConsoleKeyInfo();
            bool loggedOut = false;//TODO sätt till true vid implementerad inloggningssystem
            while (true)
            {
                if (loggedOut)//TODO ska det bara finnas ett admin lösen?(slipper roller)
                {
                    Console.WriteLine("Please log in");
                    Console.WriteLine("Username: ");
                    string username = Console.ReadLine();
                    Console.WriteLine("Password: ");
                    string password = Console.ReadLine();
                    bool logInSuccess = AdminBackend.LogIn(username, password);
                    loggedOut = false;
                }
                else
                {
                    Console.WriteLine("Choose an option: " +
                                      "\n1. Reset database" +
                                      "\n2. View all users" +
                                      "\n3. View all restaurants" +
                                      "\n4. Add new restaurant" +
                                      "\n5. Log out" +
                                      "\nPress any other key to exit program");
                    
                    key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                            AdminBackend.InitializeDatabase();
                            break;

                        case ConsoleKey.D2:
                            

                            foreach (var c in AdminBackend.GetAllCustomers())
                            {
                                Console.WriteLine($"#{c.Id} {c.CustomerPrivateInfo.First_Name} {c.CustomerPrivateInfo.Last_Name}, Phone number: {c.CustomerPrivateInfo}");
                            }
                            break;

                        case ConsoleKey.D3:

                            break;

                        case ConsoleKey.D4:

                            break;

                        case ConsoleKey.D5:
                            Console.Clear();
                            loggedOut = true;
                            break;

                        default:
                            Console.Clear();
                            return;
                    }
                }
            }
        }
    }
}

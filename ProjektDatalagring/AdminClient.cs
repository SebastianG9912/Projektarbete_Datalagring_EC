using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Data;

namespace ProjektDatalagring
{
    public class AdminClient
    {
        public static void Main(string[] args)
        {
            var key = new ConsoleKeyInfo();
            bool loggedOut = true;
            while (true)
            {
                if (loggedOut)
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

                            break;

                        case ConsoleKey.D2:

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

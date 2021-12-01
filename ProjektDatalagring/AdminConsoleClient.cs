using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace ConsoleFrontend
{
    /// <summary>
    /// Console-versionen av admin UI
    /// </summary>
    public class AdminConsoleClient
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
                    Console.WriteLine("\nChoose an option: " +
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
                            Console.Clear();
                            AdminBackend.InitializeDatabase();
                            Console.WriteLine("Database reset!");

                            Console.WriteLine("Do you want to seed database with testdata?\n" +
                                              "(y/n):");
                            var seedKey = new ConsoleKey();

                            while (true)
                            {
                                seedKey = Console.ReadKey().Key;
                                if (seedKey == ConsoleKey.Y)
                                {
                                    AdminBackend.Seed();
                                    Console.WriteLine("\nDatabase seeded!");
                                    break;
                                }
                                else if (seedKey == ConsoleKey.N)
                                {
                                    Console.WriteLine();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Do you want to seed database with testdata?\n" +
                                                      "(Please write either y (Yes) or n (No)):");
                                }
                            }
                            
                            break;

                        case ConsoleKey.D2:
                            Console.Clear();
                            var customers = AdminBackend.GetAllCustomers();

                            if (customers.Count > 0)
                                foreach (var c in customers)
                                    Console.WriteLine($"#{c.Id} {c.CustomerPrivateInfo.First_Name} {c.CustomerPrivateInfo.Last_Name}");
                            else
                                Console.WriteLine("There are no users in the database!");

                            break;

                        case ConsoleKey.D3:
                            Console.Clear();
                            var restaurants = AdminBackend.GetAllRestaurants();

                            if(restaurants.Count > 0)
                                foreach (var r in restaurants)
                                    Console.WriteLine($"#{r.Id} {r.Name}, Phone number: {r.Phone_number}, Food packages: {r.Foodpacks.Count}, Location: {r.Location}");
                            else
                                Console.WriteLine("There are no restaurants in the database!");       
                            
                            break;

                        case ConsoleKey.D4:
                            Console.Clear();
                            Console.WriteLine("Write the name of the new restaurant: ");
                            string restaurantName = Console.ReadLine();
                            Console.WriteLine("Write the location of the new restaurant: ");
                            string restaurantLocation = Console.ReadLine();
                            Console.WriteLine("Write the phone number of the new restaurant: ");
                            string restaurantPhoneNmbr = Console.ReadLine();
                            bool restaurantDoesNotExists = AdminBackend.AddNewRestaurant(restaurantName, restaurantLocation, restaurantPhoneNmbr);

                            if (!restaurantDoesNotExists)
                                Console.WriteLine("Restaurant with supplied information already exists!\n" +
                                                  "Please try again.");
                            else
                                Console.WriteLine("Restaurant successfully added!");

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

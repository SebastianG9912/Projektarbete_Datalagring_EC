﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Backend.Data
{
    public class AdminBackend
    {
        public static void InitializeDatabase()
        {
            using var ctx = new RestaurantDbContext();

            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
        }

        public static bool LogIn(string username, string password)
        {
            throw new NotImplementedException();
        }

        public static List<Customer> GetAllCustomers()
        {
            using var ctx = new RestaurantDbContext();

            return ctx.Customers
                .Include(c => c.CustomerPrivateInfo)
                .ToList();
        }

        public static List<Restaurant> GetAllRestaurants()
        {
            using var ctx = new RestaurantDbContext();

            return ctx.Resturaunts
                .Include(r => r.Foodpacks)
                .ToList();
        }

        public static bool AddNewRestaurant(string v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }
    }
}

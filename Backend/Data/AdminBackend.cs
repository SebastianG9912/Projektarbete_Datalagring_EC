using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Model;
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
            throw new NotImplementedException();
        }
    }
}

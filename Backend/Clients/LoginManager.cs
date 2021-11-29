using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Clients
{
    public class LoginManager
    {
        public CustomerPrivateInfo Login(string email, string password)
        {
            using var ctx = new RestaurantDbContext();

            var query = ctx.CustomersPrivateInfo
                .Include(c => c.customer)
                .Where(c => c.UserEmail == email && c.UserPassword == password);

            var user = query.FirstOrDefault();

            
            return user;
            
        }
    }
}

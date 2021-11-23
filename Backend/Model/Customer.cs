using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public CustomerPrivateInfo CustomerPrivateInfo { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Model
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public DateTime OrderDateTime { get; set; }
        [Required]
        public ICollection<Foodpack> Foodpacks { get; set; }
    }
}

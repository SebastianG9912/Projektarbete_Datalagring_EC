using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Model
{
    public class Foodpack
    {
        public int Id { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public Restaurant Restaurant { get; set; }
        public string Name { get; set; }
        public Order? Order { get; set; }
        [Required]
        public double Price { get; set; }
    }
}

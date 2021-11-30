using System.ComponentModel.DataAnnotations;


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

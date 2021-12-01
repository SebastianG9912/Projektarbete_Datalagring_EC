using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Phone_number { get; set; }

        public ICollection<Foodpack> Foodpacks { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;


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

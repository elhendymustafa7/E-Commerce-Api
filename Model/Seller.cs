
namespace E_Commerce_Api.Model
{
    public class Seller
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public List<Product> products { get; set; } = null!;
    }
}

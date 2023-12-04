
namespace E_Commerce_Api.Model
{
    public class Category
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public virtual List<Product> Products { get; set; } = null!;

    }
}

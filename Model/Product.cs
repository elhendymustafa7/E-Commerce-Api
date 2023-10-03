
namespace E_Commerce_Api.Model
{
    public class Product
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int SellerID { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int StockQuantity { get; set; }
        [Required]
        public string? DiscountDescription { get; set; }
        [Required]
        public decimal? DiscountPercent { get; set; }
        [Required]
        public bool IsDiscountActive { get; set; }

    }
}

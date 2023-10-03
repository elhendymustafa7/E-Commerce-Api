namespace E_Commerce_Api.DTO
{
    public class ProductDto
    {
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

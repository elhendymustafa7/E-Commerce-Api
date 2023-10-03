namespace E_Commerce_Api.DTO
{
    public class SellerDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}

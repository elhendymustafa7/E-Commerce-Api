global using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Api.DTO
{
    public class CategoryDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; } 
    }
}

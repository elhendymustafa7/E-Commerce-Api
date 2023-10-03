
namespace E_Commerce_Api.Model
{
    public class User : IdentityUser
    {
        [Required]
        public string FName { get; set; } = string.Empty;
        [Required]
        public string LName { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } 
        public DateTime ModifiedAt { get; set; }

        [Required]
        public string AddressLine1 { get; set; } = string.Empty;
        public string? AddressLine2 { get; set; } = null;
        public string? PostalCode { get; set; } = null;
        [Required]
        public string? City { get; set; } = string.Empty;

        [Required]
        public string? Country { get; set; } = string.Empty;
 
        public string? PaymentType { get; set; } = string.Empty;


        public string? Provider { get; set; } = string.Empty;


        public int AccountNo { get; set; }


        public DateTime Expiry { get; set; }

        public User() {

            UserName = $"{FName ?? ""} {LName ?? ""}".Trim();
        }
    }
}

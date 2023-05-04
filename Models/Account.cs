using System.ComponentModel.DataAnnotations;

namespace CoreStocks.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        
        public string Email { get; set; }

        public bool IsAdmin { get; set; }
    }
}

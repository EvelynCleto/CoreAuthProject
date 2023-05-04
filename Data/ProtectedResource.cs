using System.ComponentModel.DataAnnotations;

namespace CoreStocks.Data
{
    public class ProtectedResource
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string Url { get; set; }

        public bool IsPublic { get; set; }
    }
}

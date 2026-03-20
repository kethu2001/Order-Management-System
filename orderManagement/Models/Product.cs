using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace orderManagement.Models{
    public class Product{

        public int Id {get; set;}

        [Required]
        [Display(Name = "Product Number")]
        public string ProductNumber { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        public ICollection<OrderItem> OrderItem { get; set; } = new List<OrderItem>();
        
    }
}
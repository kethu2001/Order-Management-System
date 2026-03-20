using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace orderManagement.Models{
    public class Order{

        public int Id {get; set;}

        [Required]
        [Display(Name = "Order Number")]
        public string OrderNumber { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; } 

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = " Total Amount")]
        public decimal  TotalAmount { get; set; }

        public Customer? Customer { get; set; } 
        public ICollection<OrderItem> OrderItem { get; set; } = new List<OrderItem>();

        
    }
}
using System.ComponentModel.DataAnnotations;

namespace orderManagement.Models{
    public class Customer{

        public int Id {get; set;}

        [Required]
        [Display(Name = "Customer Number")]
        public string CustomerNumber { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Phone { get; set; }= string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
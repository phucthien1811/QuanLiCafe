using System.ComponentModel.DataAnnotations;

namespace QuanLiCafe.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(10)]
        public string? Gender { get; set; } // Nam, N?, Khác

        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}

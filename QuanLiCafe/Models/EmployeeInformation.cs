using System.ComponentModel.DataAnnotations;

namespace QuanLiCafe.Models
{
    public class EmployeeInformation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; } // Foreign key t?i Users

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [MaxLength(15)]
        public string? PhoneNumber { get; set; }

        [MaxLength(255)]
        public string? Address { get; set; }

        [MaxLength(10)]
        public string? Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [MaxLength(50)]
        public string? IdentityCard { get; set; }

        public DateTime? StartDate { get; set; }

        [MaxLength(500)]
        public string? Notes { get; set; }

        // Navigation property
        public virtual User User { get; set; } = null!;
    }
}

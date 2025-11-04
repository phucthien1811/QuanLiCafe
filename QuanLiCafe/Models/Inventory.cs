using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLiCafe.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string MaterialName { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Unit { get; set; } = string.Empty; // kg, lít, gói, v.v.

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ReorderLevel { get; set; }

        // Navigation properties
        public virtual ICollection<ImportHistory> ImportHistories { get; set; } = new List<ImportHistory>();
    }
}

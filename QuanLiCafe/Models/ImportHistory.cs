using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLiCafe.Models
{
    public class ImportHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MaterialId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Cost { get; set; }

        [Required]
        public DateTime ImportedAt { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("MaterialId")]
        public virtual Inventory Material { get; set; } = null!;
    }
}

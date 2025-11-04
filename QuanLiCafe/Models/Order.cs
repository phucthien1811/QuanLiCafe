using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLiCafe.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TableId { get; set; }

        [Required]
        public int StaffId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(5,2)")]
        public decimal Discount { get; set; } = 0;

        [Column(TypeName = "decimal(5,2)")]
        public decimal VAT { get; set; } = 10; // 10%

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        // Navigation properties
        [ForeignKey("TableId")]
        public virtual Table Table { get; set; } = null!;

        [ForeignKey("StaffId")]
        public virtual User Staff { get; set; } = null!;

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}

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

        // ? Cho phép NULL khi xóa nhân viên
        public int? StaffId { get; set; }
        
        // ? THÊM M?I: Thông tin khách hàng
        public int? CustomerId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(5,2)")]
        public decimal Discount { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }
        
        // ? THÊM M?I: Thông tin thanh toán
        [MaxLength(50)]
        public string? PaymentMethod { get; set; } // Ti?n m?t, Chuy?n kho?n, QR
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ReceivedAmount { get; set; } // S? ti?n khách ??a
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ChangeAmount { get; set; } // Ti?n th?i l?i

        // Navigation properties
        [ForeignKey("TableId")]
        public virtual Table Table { get; set; } = null!;

        [ForeignKey("StaffId")]
        public virtual User? Staff { get; set; }
        
        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}

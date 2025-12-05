using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestThiBackEnd.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        // Sửa thành decimal? (Nullable Decimal)
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? TotalAmount { get; set; }

        [StringLength(20)]
        public string? Status { get; set; } // Cho phép null

        public DateTime? CreatedAt { get; set; }
    }
}
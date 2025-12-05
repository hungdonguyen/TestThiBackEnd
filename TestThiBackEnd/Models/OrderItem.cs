using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestThiBackEnd.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int BookId { get; set; }

        public int Quantity { get; set; }

        // Sửa thành decimal?
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? UnitPrice { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
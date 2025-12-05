using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestThiBackEnd.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(150)]
        public string Author { get; set; } = null!;

        // Sửa double -> decimal
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        public int GenreID { get; set; }

        // Sửa int -> int? (Nullable)
        public int? StockQuantity { get; set; }

        // Sửa DateTime -> DateTime? (Nullable)
        public DateTime? CreateAt { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace TestThiBackEnd.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(255)]
        public string Description { get; set; } = null!;

        // Thêm dấu ? để cho phép Null (DB tự sinh ngày)
        public DateTime? CreatedAt { get; set; }
    }
}
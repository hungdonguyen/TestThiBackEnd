using System.ComponentModel.DataAnnotations;

namespace TestThiBackEnd.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string FullName { get; set; } = null!;

        [Required]
        [StringLength(255)]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string Role { get; set; } = null!;

        public DateTime? CreateAt { get; set; } // Cho phép null
    }
}
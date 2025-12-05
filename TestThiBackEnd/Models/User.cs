using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestThiBackEnd.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }

        [Required]

        public string Role { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}

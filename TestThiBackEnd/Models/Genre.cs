using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestThiBackEnd.Models
{
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        [Display(Name = "Name Genre")]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

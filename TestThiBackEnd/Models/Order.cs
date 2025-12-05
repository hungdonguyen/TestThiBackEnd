using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace TestThiBackEnd.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }

        public DateTime OrderDate { get; set; }

        public double TotalAmount { get; set; }

        public string Status { get; set; }

        
        public DateTime CreatedAt { get; set; }


    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestThiBackEnd.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public int OrderID { get; set; }

        public int BookId { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

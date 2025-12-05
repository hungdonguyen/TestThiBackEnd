using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Markup;

namespace TestThiBackEnd.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
        [Display(Name = "Book Title")]
        public string Title { get; set; } = null!;

        
        [Required(ErrorMessage = "Author is required")]
        [StringLength(150, ErrorMessage = "Author cannot exceed 150 characters")]
        [Display(Name = "Book Author")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Price")]
        //Price is positive
        
        public double Price { get; set; } = 0;

        public int GenreID { get; set; }

        public int StockQuantity { get; set; }

        public DateTime CreateAt { get; set; }
    }
}

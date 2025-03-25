using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name length must be between 50 characters")]
        [DisplayName("Product Name")]
        public string? ProductName { get; set; }
        public string ProductDescription { get; set; }
        [Required]
        public string? ProductISBN { get; set; }
        [Required]
        public string? ProductAuthor { get; set; }
        [Required]
        [Display(Name ="List of Book Price")]
        [Range(1,1000)]
        public double ListofPrice { get; set; }
        [Required]
        [Display(Name = "Price of Book with a quantity of 1-50")]
        [Range(1, 1000)]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Price of Books with a quantity 50+")]
        [Range(1, 1000)]
        public double ListofPrice50 { get; set; }
        [Required]
        [Display(Name = "Price of Books with a quantity 100+")]
        [Range(1, 1000)]
        public double ListofPrice100 { get; set; }

    }
}

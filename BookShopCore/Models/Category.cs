using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BookShopCore.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Name length must be between 30 characters")]
        [DisplayName("Category Name")]
        public string? CategoryName { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "The Range of order must be between 1-100")]
        public int DisplayOrder { get; set; }
    }
}

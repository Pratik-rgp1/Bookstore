using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookstoreWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("Category Name")]
        
        public string Name { get; set; }
        [Required]
        //validation for display name
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage = "Display Order must be between 1 to 100.")]
        public string DisplayOrder { get; set; }
    }
}

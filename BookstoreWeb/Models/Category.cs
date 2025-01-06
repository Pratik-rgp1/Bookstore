using System.ComponentModel.DataAnnotations;
namespace BookstoreWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "DisplayOrder must be numeric.")]
        public string DisplayOrder { get; set; }
    }
}

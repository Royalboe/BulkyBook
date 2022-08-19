using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        // To set primary key using annotations
        [Key]
        public int Id { get; set; }
        // For validation
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Value must be between 1 and 100")]
        public int DisplayOrder { get; set; }

        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}

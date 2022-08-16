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

        public int DisplayOrder { get; set; }

        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}

using System.ComponentModel.DataAnnotations;

namespace Survey_app.Models
{
    public class UniversityCampus
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }
    }
}

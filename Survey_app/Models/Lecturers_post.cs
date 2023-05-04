using System.ComponentModel.DataAnnotations;

namespace Survey_app.Models
{
    public class LecturersPost
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Position { get; set; }
        

    }
}

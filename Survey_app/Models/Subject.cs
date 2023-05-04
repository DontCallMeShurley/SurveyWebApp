using System.ComponentModel.DataAnnotations;

namespace Survey_app.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Наименование предмета")]
        public string Title { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Survey_app.Models
{
    public class StudentsGroups
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Наименование")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата создания")]
        public DateTime? CreationDate { get; set; }

        [ForeignKey("University_campus")]
        public int? UniversityCampusId { get; set; }
        public UniversityCampus? UniversityCampus { get; set; }
    }
}

using Survey_app.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Survey_app.Models
{
    public class Lecturers
    {
        [Key]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Фамилия")]
        public string SecondName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Отчество")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Пол")]
        public SexType SexType { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        public DateTime? DateOfBirth { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [ForeignKey("Lecturers_post")]
        [Display(Name = "Должность")]
        public int? LecturersPostId { get; set; }
        public LecturersPost? LecturersPost { get; set; }

        public List<SubjectsLecturers>? Subjects { get; set; }

    }
}
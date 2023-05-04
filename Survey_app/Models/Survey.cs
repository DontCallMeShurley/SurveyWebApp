using Survey_app.Data.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Survey_app.Models
{
    public class Survey
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Название опроса")]
        public string Title { get; set; }

        [StringLength(50)]
        [Display(Name = "Описание опроса")]
        public string? Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Дата начала")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата окончания")]
        public DateTime? EndDate { get; set; }

        [Required]
        [Display(Name = "Статус опроса")]
        public SurveyStatus SurveyStatus { get; set; }

        [ForeignKey("Subjects_lecturers")]
        [Display(Name = "Дисциплина и преподаватель")]
        public int SubjectsLecturersId { get; set; }
        public SubjectsLecturers SubjectsLecturers { get; set; }

        [Display(Name = "Вопросы опроса")]
        public List<Questions> SurveyQuestion { get; set; }
    }
}


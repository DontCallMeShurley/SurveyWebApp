using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Survey_app.Models
{
    public class SubjectsLecturers
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Lecturers")]
        [Display(Name = "Преподаватель")]
        public int LecturersId { get; set; }
        public Lecturers? Lecturers { get; set; }

        [ForeignKey("Subject")]
        [Display(Name = "Предмет")]
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }
    }
}

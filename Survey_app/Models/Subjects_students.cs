using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Survey_app.Models
{
    public class SubjectsStudents
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Subjects_lecturers")]
        [Display(Name = "Предмет")]
        public int SubjectsLecturersId { get; set; }
        public SubjectsLecturers? SubjectsLecturers { get; set; }


        [ForeignKey("Students_groups")]
        [Display(Name = "Группа")]
        public int? StudentsGroupsId { get; set; }
        public StudentsGroups? StudentsGroups { get; set; }

    }
}

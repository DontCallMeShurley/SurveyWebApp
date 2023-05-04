using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Survey_app.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("Students_groups")]
        [Display(Name = "Учебная группа")]
        public int? StudentsGroupsId { get; set; }
        public StudentsGroups? StudentsGroups { get; set; }

        [ForeignKey("Person")]
        [Display(Name = "Учетная запись")]
        public int PersonId { get; set; }
        public Person? Person { get; set; }
    }
}

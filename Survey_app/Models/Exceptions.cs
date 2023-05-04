

using Survey_app.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Survey_app.Models
{
    public class Exceptions
    {
        [Key]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [ForeignKey("Question")]
        [Display(Name = "Критерий")]
        public int QuestionId { get; set; }
        public Questions? Question { get; set; }
        public ExceptionType ExceptionType { get; set; }
    }
}


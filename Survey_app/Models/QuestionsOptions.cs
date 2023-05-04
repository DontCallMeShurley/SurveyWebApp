using Survey_app.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Survey_app.Models
{
    public class QuestionsOptions
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("question")]
        [Display(Name = "Вопрос")]
        public int? QuestionId { get; set; }
        public Questions? Question { get; set; }

        [Required]
        [Display(Name = "Вариант ответа")]
        public string? Text { get; set; }
    }
}
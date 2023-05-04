using Survey_app.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Survey_app.Services.ReportService;

namespace Survey_app.Models
{
    public class Questions
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Survey")]
        public int SurveyId { get; set; }
        public Survey? Survey { get; set; }

        [StringLength(200)]
        [Display(Name = "Вопрос")]
        public string? Text { get; set; }

        [Display(Name = "Тип вопроса")]
        public QuestionTypes QuestionTypes { get; set; }

        [Display(Name = "Варианты ответы")]
        public List<QuestionsOptions>? QuestionsOptions { get; set; }

    }
}
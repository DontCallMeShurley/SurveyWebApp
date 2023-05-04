using System.ComponentModel.DataAnnotations;

namespace Survey_app.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        public virtual SurveyAnswers SurveyAnswers { get; set; }
        public string Text { get; set; } = null!;
        public virtual Questions? Questions { get; set; }
    }
}

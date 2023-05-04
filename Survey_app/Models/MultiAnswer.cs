using System.ComponentModel.DataAnnotations;

namespace Survey_app.Models
{
    public class MultiAnswer
    {
        [Key]
        public int Id { get; set; }
        public virtual SurveyAnswers SurveyAnswers { get; set; }
        public virtual Questions? Questions { get; set; }
        public virtual ICollection<MultiValue> Values { get; set; }
    }
}

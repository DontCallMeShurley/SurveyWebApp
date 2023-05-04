using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Survey_app.Models
{
    public class SurveyAnswers
    {
        [Key]
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public int PersonId { get; set; }
        public virtual Survey Survey { get; set; }
        public virtual Person? Person { get; set; }
        public virtual ICollection<Answer>? Answers { get; set; }
        public virtual ICollection<MultiAnswer>? MultiAnswers { get; set; }

    }
}

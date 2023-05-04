using Survey_app.Data.Enum;
using Survey_app.Models;
using System.ComponentModel.DataAnnotations;

namespace Survey_app.ViewModels
{
    public class QuestionTypeViewModel
    {
        public int SurveyId { get; set; }

        public List<QuestionTypes> Type { get; set; }
    }
}

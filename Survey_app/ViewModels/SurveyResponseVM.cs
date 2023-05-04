using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Build.Framework;
using Survey_app.Models;

namespace Survey_app.ViewModels
{
    public class SurveyResponseVM
    {
        public RespondentSurveyVM Survey { get; set; }
        public List<AnswerVM>? Answers { get; set; }
        public List<MultiAnswer>? MultiAnswers { get; set; }
    }

    public class ResponseVM
    {
        public Person Person { get; set;}
        public List<AnswerVM>? Answers { get; set; }
        public List<MultiAnswer>? MultiAnswers { get; set; }
    }

    public class CreateResponseVM
    {
        [Required]
        public int SurveyId { get; set; }

        [ValidateNever]
        public List<AnswerVM>? Answers { get; set; }

        [ValidateNever]
        public List<CreateMultiAnswerVM>? MultiAnswers { get; set; }
    }
    public class CreateSurveyResponseVM
    {
        public RespondentSurveyVM Survey { get; set; }
        public CreateResponseVM Response { get; set; }
    } 
    public class UserViewSurveyResponseVM
    {
        public SurveyViewModel Survey { get; set; }
        public PaginatedList<ResponseVM> Responses { get; set; }
    }
}

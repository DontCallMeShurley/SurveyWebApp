using Microsoft.AspNetCore.Mvc.Rendering;
using Survey_app.Data.Enum;
using Survey_app.Models;

namespace Survey_app.ViewModels
{
    public class IndexSurveyViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public SurveyStatus SurveyStatus { get; set; }

        public int SubjectsLecturersId { get; set; }

        public SubjectsLecturers? SubjectsLecturers { get; set; }

        public List<Questions> SurveyQuestion { get; set; }
    }
}

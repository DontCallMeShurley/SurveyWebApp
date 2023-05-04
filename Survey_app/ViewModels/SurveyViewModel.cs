using Survey_app.Data.Enum;
using Survey_app.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Survey_app.ViewModels
{
    public class SurveyViewModel
    {
        [Display(Name = "ID опроса")]
        public int Id { get; set; }

        [Display(Name = "Название опроса")]
        public string Title { get; set; }

        [Display(Name = "Описание опроса")]
        public string? Description { get; set; }

        [Display(Name = "Дата начала опроса")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Дата окончания опроса")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Статус опроса")]
        public SurveyStatus SurveyStatus { get; set; }

        [Display(Name = "Преподаватели и предметы")]
        public int SubjectsLecturersId { get; set; }

        [Display(Name = "Список преподавателей и предметов")]
        public SelectList? SubjectsLecturersList { get; set; }

        [Display(Name = "Список вопросов опроса")]
        public List<SurveyQuestionViewModel>? Questions { get; set; }
    }

    public class RespondentSurveyVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<SurveyQuestionViewModel> Questions { get; set; }
    }
}

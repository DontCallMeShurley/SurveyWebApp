
using Survey_app.Data.Enum;
using Survey_app.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Survey_app.ViewModels
{
    public class SurveyQuestionViewModel 
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(200)]
        [Display(Name = "Вопрос")]
        public string Text { get; set; }

        public Survey? Survey { get; set; }

        [Display(Name = "Тип вопроса")]
        public QuestionTypes QuestionTypes { get; set; }

        [Display(Name = "Варианты ответы")]
        public List<QuestionsOptions>? QuestionsOptions { get; set; }
    }

}
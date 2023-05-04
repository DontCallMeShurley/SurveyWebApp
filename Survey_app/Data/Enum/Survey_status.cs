using System.ComponentModel.DataAnnotations;

namespace Survey_app.Data.Enum
{
    public enum SurveyStatus
    {
        [Display(Name = "Завершен")]
        Завершен,
        [Display(Name = "Идет")]
        Идет,
        [Display(Name = "Создано")]
        Создано
    }
}

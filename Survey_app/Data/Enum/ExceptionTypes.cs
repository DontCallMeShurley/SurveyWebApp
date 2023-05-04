using System.ComponentModel.DataAnnotations;

namespace Survey_app.Data.Enum
{
    public enum ExceptionType
    {

        [Display(Name = "Предмет")]
        Subject = 0,

        [Display(Name = "Учитель")]
        Lectures = 1,

    }

}
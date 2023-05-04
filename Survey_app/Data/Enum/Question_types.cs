using System.ComponentModel.DataAnnotations;

namespace Survey_app.Data.Enum
{
    public enum QuestionTypes
    {

        [System.Runtime.Serialization.EnumMember(Value = @"Text")]
        [Display(Name = "Текстовый")]
        Text = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"Radio")]
        [Display(Name = "Одновыборочный")]
        Radio = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"Checkbox")]
        [Display(Name = "Многовыборочный")]
        Checkbox = 2,

    }
}

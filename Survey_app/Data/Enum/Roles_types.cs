using System.ComponentModel.DataAnnotations;

namespace Survey_app.Data.Enum
{
    public enum RolesTypes
    {
        [Display(Name = "Админ")]
        Admin,
        [Display(Name = "Студент")]
        Student,
        [Display(Name = "Секретарь")]
        Secretary
    }
}

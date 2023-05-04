using Survey_app.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection;

namespace Survey_app.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Фамилия")]
        public string SecondName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Отчество")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Пол")]
        public SexType SexType { get; set; }

        [EmailAddress]
        [Display(Name = "Адрес электронной почты")]
        public string? Email { get; set; }

        [StringLength(100)]
        [Display(Name = "Логин")]
        public string? Login { get; set; }

        [StringLength(100)]
        [Display(Name = "Пароль")]
        public string? Password { get; set; }

        [Required]
        [Display(Name = "Роль")]
        public RolesTypes RolesTypes { get; set; }

        [NotMapped]
        [Display(Name = "ФИО")]
        public string Fio => SecondName + " " + FirstName + " " + LastName;
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using Survey_app.Data.Enum;
using Survey_app.Models;

namespace Survey_app.ViewModels
{
    public class LecturesSubjects
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public SexType SexType { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Email { get; set; }

        public int LecturersPostId { get; set; }
        public LecturersPost? LecturersPost { get; set; }
        public List<SubjectsLecturers> Subjects { get; set;}
    }
}

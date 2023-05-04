using Survey_app.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Survey_app.Data.Enum;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Survey_app.ViewModels
{
    public class LecturersViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public SexType SexType { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Email { get; set; }

        public int LecturersPostId { get; set; }
        public SelectList? LecturersPostList { get; set; }
    }
}

using Survey_app.Data;
using Survey_app.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace Survey_app.Repository
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool VerifyUser(string email, string password)
        {
            var user = _context.Persons.FirstOrDefault(x => x.Email == email);
            if (user == null)
            {
                return false;
            }
            return BCrypt.Net.BCrypt.Verify(password, user.Password);
        }
        public Person? GetPersonByEmail(string email)
        {
            return _context.Persons.FirstOrDefault(x => x.Email == email);
        }
        public Students? GetStudents(Person person)
        {
            return _context.Students.Include(x => x.StudentsGroups).FirstOrDefault(x => x.PersonId == person.Id);
        }
        public List<SubjectsStudents>? GetSubjectsStudentsList(Students students)
        {
            var count = _context.SubjectsStudents.Count();
            List<SubjectsStudents> subjects = new List<SubjectsStudents>();
            if (count > 0)
            {
                subjects = _context.SubjectsStudents.Include(x => x.SubjectsLecturers).ThenInclude(x => x.Subject)

                    .Where(x => x.StudentsGroupsId == students.StudentsGroupsId).ToList();
            }
            return subjects;
        }

        public int GetCountSurveys(Students students)
        {
            var count = _context.SurveyAnswers.Count();
            if (count > 0)
            {
                return _context.SurveyAnswers.Count(a => a.PersonId == students.PersonId);
            }
            else
            {
                return 0;
            }
        }
    }
}
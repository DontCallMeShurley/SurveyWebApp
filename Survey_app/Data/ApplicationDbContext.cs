using Microsoft.EntityFrameworkCore;
using Survey_app.Models;

namespace Survey_app.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) : base(options)
        {
            
        }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<AnswerType> AnswerTypes { get; set; }
        public DbSet<Lecturers> Lecturers { get; set; }
        public DbSet<LecturersPost> LecturersPosts { get; set; }
        public DbSet<Exceptions> Exceptions { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<QuestionsOptions> QuestionsOptions { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<StudentsGroups> StudentsGroups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectsLecturers> SubjectsLecturers { get; set; }
        public DbSet<SubjectsStudents> SubjectsStudents { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyAnswers> SurveyAnswers { get; set; }
        public DbSet<UniversityCampus> UniversityCampuses { get; set; }

    }
}

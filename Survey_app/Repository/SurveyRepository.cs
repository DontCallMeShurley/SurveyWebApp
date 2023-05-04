using Microsoft.EntityFrameworkCore;
using Survey_app.Data;
using Survey_app.Data.Enum;
using Survey_app.Models;

namespace Survey_app.Repository
{
    public class SurveyRepository
    {
        private readonly ApplicationDbContext _context;

        public SurveyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Survey survey)
        {
            _context.Add(survey);
            return Save();
        }
        public bool AddAnswer(SurveyAnswers answers)
        {
            _context.Add(answers);
            return Save();
        }
        public bool Delete(Survey survey)
        {
            var answers = _context.Answer.Include(a => a.Questions).Where(a => a.Questions.SurveyId == survey.Id)
                .ToList();
            _context.RemoveRange(answers);

            _context.Remove(survey);
            return Save();
        }

        public async Task<IEnumerable<Survey>> GetAll(Person person)
        {
            if (person.RolesTypes != RolesTypes.Student)
                return await _context.Surveys.Include(x => x.SurveyQuestion).ToListAsync();
            else
            {
                var student = _context.Students.First(x => x.PersonId == person.Id);
                var subjectsGroups =
                    _context.SubjectsStudents.Where(x => x.StudentsGroupsId == student.StudentsGroupsId).Select(x => x.SubjectsLecturersId).ToList();
                var completedSurveys = _context.SurveyAnswers.Include(x => x.Survey).Where(x => x.PersonId == person.Id)
                    .Select(x => x.Survey).ToList();

                return await _context.Surveys.Include(x => x.SurveyQuestion)
                    .Where(x => subjectsGroups.Contains(x.SubjectsLecturersId) && !completedSurveys.Contains(x)).ToListAsync();

            }
        }

        public async Task<Survey?> GetByIdAsync(int id)
        {
            return await _context.Surveys.Include(i => i.SubjectsLecturers).Include(i => i.SurveyQuestion).ThenInclude(x => x.QuestionsOptions).FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
        public async Task<List<Questions>> GetAllQuestions()
        {
            var questions = await _context.Questions.ToListAsync();
            return questions;

        }
        public async Task<List<Questions>> GetQuestionBySurveyId(int surveyId)
        {

            var surveyQuestions = await _context.Questions.Where(a => a.SurveyId == surveyId).ToListAsync();
            return surveyQuestions;

        }
        public async Task<Survey> GetSurveyByQuestion(int questionId)
        {
            var survey = await _context.Questions.Where(a => a.Id == questionId).Select(a => a.Survey).FirstAsync();
            return survey;

        }

        public bool Update(Survey survey)
        {
            _context.Update(survey);
            return Save();
        }
    }
}

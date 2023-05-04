using Microsoft.EntityFrameworkCore;
using Survey_app.Data;
using Survey_app.Data.Enum;
using Survey_app.Dtos;

namespace Survey_app.Services
{
    public class ReportService
    {
        private readonly ApplicationDbContext _context;

        public ReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ReportDto>> GetDataForChart(int surveyId)
        {
            var questions = await _context.Questions.Where(x => x.SurveyId == surveyId && x.QuestionTypes == QuestionTypes.Radio).ToListAsync();
            var answers = await _context.Answer.Include(x => x.Questions).Where(x =>
                x.Questions.QuestionTypes == QuestionTypes.Radio && x.Questions.Survey.Id == surveyId).ToListAsync();

            var result = questions.Select(x => new ReportDto()
            {
                Questions = x,
                AnswersReports = answers.Where(y => y.Questions.Id == x.Id).GroupBy(y => y.Text).Select(y =>
                    new AnswersReport()
                    {
                        NameAnswer = y.Key,
                        CountAnswers = y.Count()
                    }).ToList()
            }).ToList();
            return result;
        }
    }
}

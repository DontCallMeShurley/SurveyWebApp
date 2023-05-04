using DevExpress.Entity.Model.Metadata;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Survey_app.Data;
using Survey_app.Models;
using Survey_app.Repository;
using Survey_app.ViewModels;
//TODO: add mapper
namespace Survey_app.Services
{
    public class SurveyResponseService
    {
        private readonly ApplicationDbContext _context;
        public SurveyResponseService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<UserViewSurveyResponseVM> GetResponsesBySurveyId(int surveyId, string searchString, int? pageNumber)
        {
            var responses = await _context.SurveyAnswers.Where(a => a.SurveyId == surveyId)
                                                                                                                        .Include(x => x.Survey)
                                                                                                                                    .ThenInclude(x => x.SurveyQuestion)
                                                                                                                        .Include(x => x.Answers)
                                                                                                                        .Include(x => x.MultiAnswers)
                                                                                                                        .ThenInclude(x => x.Values)
                                                                                                                        .Include(x => x.Person)
                .ToListAsync();
            var survey = await _context.Surveys.Where(a => a.Id == surveyId).FirstOrDefaultAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                responses = responses.Where(r => r.Answers.Any(a => a.Text.Contains(searchString, StringComparison.OrdinalIgnoreCase)) || r.Answers.Any(a => a.SurveyAnswers.Person.Fio.Contains(searchString, StringComparison.OrdinalIgnoreCase)) ||
                                                 r.MultiAnswers.Any(m => m.Values.Any(v => v.Value.Contains(searchString, StringComparison.OrdinalIgnoreCase)))).ToList();
            }

            //var responseVM = _mapper.Map<List<ResponseVM>>(responses);
            var responseVM = responses.Select(surveyAnswers => new ResponseVM()
            {
                Person = surveyAnswers.Person,
                Answers = surveyAnswers.Answers?.Select(answer => new AnswerVM()
                {
                    Text = answer.Text
                }).ToList(),
                MultiAnswers = surveyAnswers.MultiAnswers?.ToList()
            }).ToList();
            var a = PaginatedList<ResponseVM>.Create(responseVM, pageNumber ?? 1, 10);
            return new UserViewSurveyResponseVM
            {
                Survey = new SurveyViewModel()
                {
                    Description = survey.Description,
                    EndDate = survey.EndDate,
                    Id = survey.Id,
                    Questions = survey.SurveyQuestion.Select(x => new SurveyQuestionViewModel()
                    {
                        Id = x.Id,
                        QuestionsOptions = x.QuestionsOptions,
                        QuestionTypes = x.QuestionTypes,
                        Survey = survey,
                        Text = x.Text
                    }).ToList(),
                    StartDate = survey.StartDate,
                    SubjectsLecturersId = survey.SubjectsLecturersId,
                    SurveyStatus = survey.SurveyStatus,
                    Title = survey.Title
                },
                Responses = PaginatedList<ResponseVM>.Create(responseVM, pageNumber ?? 1, 10)
            };
        }
        public async Task<CreateSurveyResponseVM> GetSurveyWithCreateResponse(int id)
        {
            var survey = await _context.Surveys.Include(x => x.SurveyQuestion).ThenInclude(x => x.QuestionsOptions).FirstOrDefaultAsync(x => x.Id == id);
            return new CreateSurveyResponseVM
            {
                Survey = new RespondentSurveyVM()
                {
                    Id = survey.Id,
                    Questions = survey.SurveyQuestion.Select(x => new SurveyQuestionViewModel()
                    {
                        Id = x.Id,
                        QuestionsOptions = x.QuestionsOptions,
                        QuestionTypes = x.QuestionTypes,
                        Survey = survey,
                        Text = x.Text
                    }).ToList(),
                    Title = survey.Title
                }
            };
        }
        public async Task<int> CreateSurveyResponse(CreateResponseVM createResponse, int surveyId, Person userPerson)
        {
            var surveyAnswer = new SurveyAnswers()
            {
                Person = userPerson,
                SurveyId = surveyId,
                Answers = createResponse.Answers?.Select(x => new Answer
                {
                    Text = x.Text,
                    Questions = _context.Questions.FirstOrDefault(y => y.Id == x.QuestionId)
                }).ToList(),
                MultiAnswers = createResponse.MultiAnswers?.Select(x => new MultiAnswer()
                {
                    Questions = _context.Questions.FirstOrDefault(y => y.Id == x.QuestionId),
                    Values = x.Values.Select(y => new MultiValue()
                    {
                        MultiAnswerId = y.MultiAnswerId,
                        Value = y.Value
                    }).ToList()
                }).ToList()

            };
            var id = _context.SurveyAnswers.Add(surveyAnswer);
            await _context.SaveChangesAsync();
            return id.Entity.Id;
        }
        public async Task<SurveyResponseVM> GetResponse(int id)
        {
            var response = await _context.SurveyAnswers.Include(x => x.Answers).Include(x => x.Survey).ThenInclude(x => x.SurveyQuestion).Include(x => x.MultiAnswers).ThenInclude(y => y.Values).FirstOrDefaultAsync(x => x.Id == id);
            return new SurveyResponseVM()
            {
                Answers = response.Answers.Select(x => new AnswerVM { Text = x.Text }).ToList(),
                MultiAnswers = response.MultiAnswers.ToList(),
                Survey = new RespondentSurveyVM()
                {
                    Id = response.Survey.Id,
                    Questions = response.Survey.SurveyQuestion.Select(x => new SurveyQuestionViewModel()
                    {
                        Id = x.Id,
                        QuestionsOptions = x.QuestionsOptions,
                        QuestionTypes = x.QuestionTypes,
                        Survey = response.Survey,
                        Text = x.Text
                    }).ToList(),
                    Title = response.Survey.Title
                }
            };
        }
    }
}

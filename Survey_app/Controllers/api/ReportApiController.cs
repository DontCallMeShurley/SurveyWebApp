using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.XtraCharts;
using Newtonsoft.Json.Linq;
using Survey_app.Data;
using Survey_app.Models;
using System.Text.Json.Nodes;
using Microsoft.CodeAnalysis;
using Survey_app.Data.Enum;

namespace Survey_app.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]

    public class ReportApiController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ReportApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetCompletedSurveys")]
        public async Task<IActionResult> GetCompletedSurveys()
        {
            var studentGroupsList = await _context.StudentsGroups.ToListAsync();
            var surveyList = await _context.Surveys.ToListAsync();
            var answerList = await _context.SurveyAnswers.ToListAsync();
            var students = await _context.Students.ToListAsync();

            JArray jsonArray = new JArray();

            foreach (var survey in surveyList)
            {
                JObject jsonObject = new JObject();

                jsonObject.Add("Наименование опроса", survey.Title);

                foreach (var studentGroup in studentGroupsList)
                {
                    jsonObject.Add(studentGroup.Title, answerList.Count(x => x.SurveyId == survey.Id && students.FirstOrDefault(y => y.PersonId == x.PersonId)?.StudentsGroupsId == studentGroup.Id));
                }

                jsonArray.Add(jsonObject);
            }

            var a = new JsonResult(jsonArray);
            return Content(JsonConvert.SerializeObject(jsonArray), "application/json");
        }
        [Route("GetRaitingTeachers")]
        public async Task<IActionResult> GetRaitingTeachers()
        {
            //Логика отчёта такая : взять список критериев, взять список преподов, взять список вопросов по критериям и, где ответ = число. Подсчитать Запихнуть это в JsonArray и вернуть представлению
            var criteriaList = await _context.Exceptions.Include(x => x.Question).Where(x => x.ExceptionType == ExceptionType.Lectures).Select(x => x.Question).ToListAsync();
            var lecturesList = await _context.Lecturers.ToListAsync();
            var answerList = await _context.Answer.Include(x => x.Questions).ThenInclude(x => x.Survey).ThenInclude(x => x.SubjectsLecturers).Where(x => x.Questions.QuestionTypes == QuestionTypes.Radio).Where(x => criteriaList.Select(x => x.Text).Contains(x.Questions.Text)).ToListAsync();


            JArray jsonArray = new JArray();
            foreach (var lectures in lecturesList)
            {
                JObject jsonObject = new JObject
                {
                    { "Преподаватель", lectures.SecondName + " " + lectures.FirstName + " " + lectures.LastName }
                };
                int k = 0;
                var comp = answerList.Where(x => int.TryParse(x.Text, out k) && x.Questions.Survey.SubjectsLecturers.LecturersId == lectures.Id).GroupBy(x => x.Questions.Text.Trim()).Select(x => new
                {
                    Name = x.Key,
                    Average = Math.Round(x.Average(y => int.Parse(y.Text)), 2)
                });
                foreach (var compilation in comp)
                {
                    jsonObject.Add(compilation.Name, compilation.Average);
                }
                //Добавить нули к отчёту
                foreach (var collAnswer in answerList.Where(x => int.TryParse(x.Text, out k) && !comp.Select(a => a.Name).Contains(x.Questions.Text)).GroupBy(x => x.Questions.Text.Trim()))
                {
                    jsonObject.Add(collAnswer.Key, 0);
                }
                jsonObject.Add("Итого", comp.Any() ? comp.Average(x => x.Average) : 0);
                jsonArray.Add(jsonObject);
            }
            return Content(JsonConvert.SerializeObject(jsonArray), "application/json");
        }
        [Route("GetRaitingSubjects")]
        public async Task<IActionResult> GetRaitingSubjects()
        {
            var criteriaList = await _context.Exceptions.Include(x => x.Question).Where(x => x.ExceptionType == ExceptionType.Subject).Select(x => x.Question).ToListAsync();
            var subjectList = await _context.Subjects.ToListAsync();
            var answerList = await _context.Answer.Include(x => x.Questions).ThenInclude(x => x.Survey).ThenInclude(x => x.SubjectsLecturers).Where(x => criteriaList.Select(x => x.Text).Contains(x.Questions.Text)).ToListAsync();


            JArray jsonArray = new JArray();

            foreach (var subject in subjectList)
            {
                JObject jsonObject = new JObject
                {
                    { "Предмет", subject.Title }
                };
                int k = 0;
                var comp = answerList.Where(x => int.TryParse(x.Text, out k) && x.Questions.Survey.SubjectsLecturers.SubjectId == subject.Id).GroupBy(x => x.Questions.Text.Trim()).Select(x => new
                {
                    Name = x.Key,
                    Average = Math.Round(x.Average(y => int.Parse(y.Text)), 2)
                }).ToList();
                foreach (var compilation in comp)
                {
                    jsonObject.Add(compilation.Name, compilation.Average);
                }

                var notInList = answerList
                    .Where(x => int.TryParse(x.Text, out k) && !comp.Select(a => a.Name).Contains(x.Questions.Text))
                    .GroupBy(x => x.Questions.Text);
                foreach (var collAnswer in notInList)
                {
                    jsonObject.Add(collAnswer.Key, 0);
                }
                jsonObject.Add("Итого", comp.Any() ? comp.Average(x => x.Average) : 0);
                jsonArray.Add(jsonObject);
            }


            return Content(JsonConvert.SerializeObject(jsonArray), "application/json");
        }
    }
}

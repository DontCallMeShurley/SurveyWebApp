using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Survey_app.Data.Enum;
using Survey_app.Models;
using Survey_app.Repository;
using Survey_app.ViewModels;
using System.Net;
using Survey_app.Data.Enum;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Survey_app.Controllers
{
    public class SurveyController : Controller
    {
        private readonly SurveyRepository _surveyRepository;
        private readonly SubjectsLecturersRepository _subjectsLecturersRepository;
        private readonly UserRepository _userRepository;

        private Person? currentUser => GetCurrentUser();
        public SurveyController(SurveyRepository surveyRepository, SubjectsLecturersRepository subjectsLecturersRepository, UserRepository userRepository)
        {
            _surveyRepository = surveyRepository;
            _subjectsLecturersRepository = subjectsLecturersRepository;
            _userRepository = userRepository;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var subjectsLecturers = await _subjectsLecturersRepository.GetAll();

            var subjectsLecturersList = subjectsLecturers.Select(l => new SelectListItem
            {
                Value = l.Id.ToString(),
                Text = l.Lecturers.FirstName + " " + l.Lecturers.LastName + "-" + l.Subject.Title
            }).ToList();

            var surveyVm = new SurveyViewModel
            {
                SubjectsLecturersList = new SelectList(subjectsLecturersList, "Value", "Text")
            };
            List<Questions> allQuestions = new List<Questions>();
            allQuestions.Add(new Questions() { });
            var all = await _surveyRepository.GetAllQuestions();
            allQuestions.AddRange(all);

            ViewBag.QuestionsId = new SelectList(allQuestions, "Id", "Text");
            return View(surveyVm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SurveyViewModel surveyVm)
        {
            if (ModelState.IsValid)
            {
                var survey = new Survey
                {
                    Title = surveyVm.Title,
                    Description = surveyVm.Description,
                    StartDate = surveyVm.StartDate,
                    EndDate = surveyVm.EndDate,
                    SurveyStatus = SurveyStatus.Создано,
                    SubjectsLecturersId = surveyVm.SubjectsLecturersId,
                    SurveyQuestion = surveyVm.Questions.Select(a => new Questions()
                    {
                        Id = a.Id,
                        QuestionTypes = a.QuestionTypes,
                        QuestionsOptions = a.QuestionsOptions,
                        SurveyId = surveyVm.Id,
                        Text = a.Text
                    }).ToList()

                };
                _surveyRepository.Add(survey);

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Проверьте правильность введенных данных");
            }

            return View(surveyVm);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var surveys = await _surveyRepository.GetByIdAsync(id);
            var subjectsLecturers = await _subjectsLecturersRepository.GetAll();

            var subjectsLecturersList = subjectsLecturers.Select(l => new SelectListItem
            {
                Value = l.Id.ToString(),
                Text = l.Lecturers.FirstName + " " + l.Lecturers.LastName + "-" + l.Subject.Title
            }).ToList();

            if (surveys == null) return View("Error");

            var surveysVm = new SurveyViewModel
            {
                Id = id,
                Title = surveys.Title,
                Description = surveys.Description,
                StartDate = surveys.StartDate,
                EndDate = surveys.EndDate,
                SurveyStatus = surveys.SurveyStatus,
                SubjectsLecturersId = surveys.SubjectsLecturersId,
                SubjectsLecturersList = new SelectList(subjectsLecturersList, "Value", "Text"),
                Questions = surveys.SurveyQuestion.Select(x=>new SurveyQuestionViewModel(){Id = x.Id, 
                                                                                                                                                            QuestionsOptions = x.QuestionsOptions, 
                                                                                                                                                            QuestionTypes = x.QuestionTypes, 
                                                                                                                                                            Text = x.Text, Survey = x.Survey}).ToList(),
            };
            return View(surveysVm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var survey = await _surveyRepository.GetByIdAsync(id);
            _surveyRepository.Delete(survey);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, SurveyViewModel surveyVm)
        {
            if (ModelState.IsValid)
            {
                var survey = new Survey
                {
                    Id = id,
                    Title = surveyVm.Title,
                    Description = surveyVm.Description,
                    StartDate = surveyVm.StartDate,
                    EndDate = surveyVm.EndDate,
                    SurveyStatus = SurveyStatus.Создано,
                    SubjectsLecturersId = surveyVm.SubjectsLecturersId,
                    SurveyQuestion = surveyVm.Questions.Select(a => new Questions()
                    {
                        Id = a.Id,
                        QuestionTypes = a.QuestionTypes,
                        QuestionsOptions = a.QuestionsOptions,
                        SurveyId = surveyVm.Id,
                        Text = a.Text
                    }).ToList()

                };
                _surveyRepository.Update(survey);
            }
            else
            {
                ModelState.AddModelError("", "Не удалось внести изменения");
                return View("Error", surveyVm);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> SendSurveyAnswers(IEnumerable<SurveyAnswers> answers)
        {
            foreach (var surveyAnswers in answers)
            {
                _surveyRepository.AddAnswer(surveyAnswers);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Index()
        {
            var surveys = await _surveyRepository.GetAll(currentUser);
            var surveyVm = new List<IndexSurveyViewModel>();
            foreach (var survey in surveys)
            {
                var subjectsLecturers = await _subjectsLecturersRepository.GetByIdAsync(survey.SubjectsLecturersId);
                surveyVm.Add(new IndexSurveyViewModel
                {
                    Id = survey.Id,
                    Title = survey.Title,
                    Description = survey.Description,
                    StartDate = survey.StartDate,
                    EndDate = survey.EndDate,
                    SurveyStatus = survey.SurveyStatus,
                    SubjectsLecturersId = survey.SubjectsLecturersId,
                    SubjectsLecturers = subjectsLecturers,
                    SurveyQuestion = survey.SurveyQuestion
                });
            }
            return View(surveyVm);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Survey survey = await _surveyRepository.GetByIdAsync(id);
            var subjectsLecturers = await _subjectsLecturersRepository.GetByIdAsync(survey.SubjectsLecturersId);
            var surveyVm = new IndexSurveyViewModel
            {
                Id = survey.Id,
                Title = survey.Title,
                Description = survey.Description,
                StartDate = survey.StartDate,
                EndDate = survey.EndDate,
                SurveyStatus = survey.SurveyStatus,
                SubjectsLecturersId = survey.SubjectsLecturersId,
                SubjectsLecturers = subjectsLecturers,
                SurveyQuestion = survey.SurveyQuestion
            };

            return View(surveyVm);
        }
        private Person? GetCurrentUser()
        {
            var email = HttpContext.User.Claims.FirstOrDefault().Value;//По идее в первом элементе держу эмайл юзера, логично что его и беру
            return _userRepository.GetPersonByEmail(email);
        }
    }
}

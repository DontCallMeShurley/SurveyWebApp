using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Survey_app.ViewModels;
using System.Security.Claims;
using DevExpress.ReportServer.ServiceModel.Client;
using DevExpress.Entity.Model.Metadata;
using Survey_app.Data;
using Survey_app.Services;
using Survey_app.Models;
using Survey_app.Repository;

namespace Survey_app.Controllers
{
    [Authorize]
    public class SurveyResponseController : Controller
    {
        private readonly UserRepository _userRepository;
        private Person CurrentUser => GetCurrentUser();

        private readonly SurveyResponseService _surveyResponseService;
        public SurveyResponseController(SurveyResponseService surveyResponseService, UserRepository userRepository)
        {
            _surveyResponseService = surveyResponseService;
            _userRepository = userRepository;
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(int id, string searchString, int? pageNumber)
        {
            ViewData["Search"] = searchString;
            var model = await _surveyResponseService.GetResponsesBySurveyId(id, searchString, pageNumber);
            return View(model);
        }


        public async Task<IActionResult> Respond(int id)
        {
            var model = await _surveyResponseService.GetSurveyWithCreateResponse(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateSurveyResponseVM surveyResponse)
        {
            var response = await _surveyResponseService.CreateSurveyResponse(surveyResponse.Response, surveyResponse.Survey.Id, CurrentUser);
            return RedirectToAction(nameof(Created), new { id = response });
        }

        public async Task<IActionResult> Created(int id)
        {
            var model = await _surveyResponseService.GetResponse(id);

            return View(model);
        }
        private Person GetCurrentUser()
        {
            var email = HttpContext.User.Claims.FirstOrDefault().Value;//По идее в первом элементе держу эмайл юзера, логично что его и беру
            return _userRepository.GetPersonByEmail(email);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Survey_app.Models;
using Survey_app.Repository;
using Survey_app.Services;

namespace Survey_app.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReportController : Controller
    {
        private readonly UserRepository _userRepository;
        private Person CurrentUser => GetCurrentUser();

        private readonly ReportService _reportService;
        public ReportController(ReportService reportService, UserRepository userRepository)
        {
            _reportService = reportService;
            _userRepository = userRepository;
        }
        public IActionResult IndexAsync()
        {

            return View();
        }
        public IActionResult CompletedSurveys()
        {
            return View();
        }
        public IActionResult RatingTeachers()
        {
            return View();
        }
        public IActionResult RatingSubjects()
        {
            return View();
        }
        public async Task<IActionResult> Charts(int id)
        {
            var result = await _reportService.GetDataForChart(id);
            return View(result);
        }
        private Person GetCurrentUser()
        {
            var email = HttpContext.User.Claims.FirstOrDefault().Value;//По идее в первом элементе держу эмайл юзера, логично что его и беру
            return _userRepository.GetPersonByEmail(email);
        }
    }
}

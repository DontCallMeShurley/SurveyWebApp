using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Survey_app.Models;
using Microsoft.AspNetCore.Authorization;
using Survey_app.Repository;

namespace Survey_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserRepository _userRepository;
        private  Person CurrentUser => GetCurrentUser();
        public HomeController(ILogger<HomeController> logger, UserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }
        [Authorize]
        public IActionResult Index()
        {
            var student = _userRepository.GetStudents(CurrentUser);
            ViewBag.Student = student;
            ViewBag.Subjects = _userRepository.GetSubjectsStudentsList(student).Select(a=>a.SubjectsLecturers.Subject.Title);
            ViewBag.CountSurveys = _userRepository.GetCountSurveys(student);
            return View(CurrentUser);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> LogOut()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Access");
        }

        private Person GetCurrentUser()
        { 
            var email = HttpContext.User.Claims.FirstOrDefault().Value;//По идее в первом элементе держу эмайл юзера, логично что его и беру
            return _userRepository.GetPersonByEmail(email);
        }
    }
}
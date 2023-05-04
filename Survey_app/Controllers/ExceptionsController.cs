using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Survey_app.Controllers
{
    [Authorize(Roles = "Admin, Secretary")]
    public class ExceptionsController : Controller
    {

        public IActionResult ListSubjects()
        {
            return View();
        }
        public IActionResult ListLectures()
        {
            return View();
        }
    }
}

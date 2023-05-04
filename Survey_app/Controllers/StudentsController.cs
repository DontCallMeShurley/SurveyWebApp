using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Survey_app.Data;
using Survey_app.Data.Enum;
using Survey_app.Models;
using Survey_app.Repository;
using Survey_app.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Survey_app.Controllers
{
    public class StudentsController : Controller
    {
        [Authorize(Roles = "Admin, Secretary")]
        public IActionResult List()
        {
            return View();
        }
    }
}

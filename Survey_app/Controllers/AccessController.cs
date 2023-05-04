using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Survey_app.Models;
using Survey_app.Repository;
using System.ComponentModel;
using Newtonsoft.Json.Linq;

namespace AuthProject.Controllers
{
    public class AccessController : Controller
    {
        private readonly UserRepository _userRepository;

        public AccessController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(VmLogin modelLogin)
        {
            if (_userRepository.VerifyUser(modelLogin.Email, modelLogin.Password)
                )
            {
                var user = _userRepository.GetPersonByEmail(modelLogin.Email);
                var role = Enum.GetName(user.RolesTypes);

                List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, modelLogin.Email),
                    new Claim(ClaimTypes.Name, modelLogin.Email),
                    new Claim(ClaimTypes.Role,role ?? ""),
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {

                    AllowRefresh = true,
                    IsPersistent = modelLogin.KeepLoggedIn
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);

                return RedirectToAction("Index", "Home");
            }



            ViewData["ValidateMessage"] = "Неправильные данные для входа";
            return View();
        }
    }
}

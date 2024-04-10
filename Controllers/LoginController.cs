
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Management.Smo;
using ResearchProflie.Services;
using System.ComponentModel.DataAnnotations;

namespace ResearchProflie.Controllers
{
    public class LoginController : Controller
    {

        private readonly P_Login _loginService;
        private readonly ILogger<LoginController> _logger;


        [BindProperty]
        [EmailAddress]
        public string Email { get; set; }


        [BindProperty]
        public string Password { get; set; }


        public IActionResult Login()
        {
            return View();
        }

        public LoginController(P_Login loginService, ILogger<LoginController> logger)
        {
            _loginService = loginService;
            _logger = logger;
        }



        [HttpPost]
        public async Task<IActionResult> LoginUser()
        {
            string email = Request.Form["email"];
            string password = Request.Form["password"];

            // Now you have the email and password, and you can proceed with the login logic.

            bool loginResult = await _loginService.LoginAsync(email, password);

            if (loginResult == true)
            {
                return RedirectToAction("Home");
                _logger.LogInformation("routing");
            }
            else
            {
                ViewData["ErrorMessage"] = "Invalid login attempt.";
                _logger.LogInformation("Not routing");
                return View("Home");
            }
        }



        public IActionResult Logout()
        {
            _loginService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

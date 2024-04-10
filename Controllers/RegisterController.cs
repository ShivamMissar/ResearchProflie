using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ResearchProflie.Services;
using System.ComponentModel.DataAnnotations;

namespace ResearchProflie.Controllers
{
    public class RegisterController : Controller
    {
        private readonly P_Register _services;
        public RegisterController(P_Register services)
        {
            _services = services;
        }
        public IActionResult Register()
        {
            return View();
        }
        [BindProperty]
        [Required]
        public string _FirstName { get; set; }

        [BindProperty]
        [Required]
        public string _LastName { get; set; }

        [BindProperty]
        [Required]
        [EmailAddress]
        public string _Email { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        public string _Password { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Date)]
        public DateTime _Age { get; set; }

        [BindProperty]
        [Required]
        public string _address { get; set; }

        [BindProperty]
        [Required]
        public string _role { get; set; }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registeruser()
        {
            if (ModelState.IsValid)
            {
                var result = await _services.RegisterUserAsync(_FirstName,_LastName,_Email,_Password,_Age, _address, _role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login","Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        
                    }
                }
            }

            // If registration fails or model is not valid, return the view with validation errors
            return View("Register");
        }

    }
}

       
   


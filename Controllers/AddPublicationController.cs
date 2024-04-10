using Microsoft.AspNetCore.Mvc;
using ResearchProflie.Models;
using ResearchProflie.Services;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace ResearchProflie.Controllers
{
    public class AddPublicationController : Controller
    {

        private readonly Appdatacontext _appdatacontext;
        private readonly P_AddPublication _p_AddPublication;


        [BindProperty]
        public string publicationTitle { get; set; }

        [BindProperty]
        public DateTime publicationDate { get; set; }

        [BindProperty]
        string publicationDescription { get; set; }


        
        public AddPublicationController(Appdatacontext appdatacontext, P_AddPublication p_AddPublication) 
        {
            _appdatacontext = appdatacontext;
            _p_AddPublication = p_AddPublication;
        }





        public IActionResult CreatePublication()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePublications()
        {
            string researcherId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var publication = new Publications
            {
                PublicationTitle = publicationTitle,

                PublicationDate = publicationDate,

                PublicationDescription = publicationDescription,

                ResearcherId = researcherId

            };

            var newPublicationCreated = await _p_AddPublication.CreatePublicationAsync(publication);

           return View();
        }

        
    }
}

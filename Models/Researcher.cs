using Microsoft.AspNetCore.Identity;

namespace ResearchProflie.Models
{
    public class Researcher : IdentityUser
    {

       
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string address { get; set; }

        public DateTime Age { get; set; }
        public ICollection<Publications> Publications { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResearchProflie.Models
{
    [PrimaryKey(nameof(PublicationId))]
    public class Publications
    {
        public int PublicationId { get; set; }

        public string PublicationTitle { get; set; }
        public DateTime PublicationDate { get; set; }
        public string PublicationDescription { get; set; }
        public string ResearcherId { get; set; } // FK
        public Researcher ResearcherUser { get; set; }
    }
}

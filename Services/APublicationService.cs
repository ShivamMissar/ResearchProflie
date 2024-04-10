using Microsoft.AspNetCore.Mvc;
using ResearchProflie.Models;

namespace ResearchProflie.Services
{
    public interface APublicationService
    {
        Task<List<Publications>> GetPublicationAsync();


        Task<Publications> GetPublicationByIdAsync(int publicationId);

        Task<Publications> CreatePublicationAsync(Publications publication);

        Task UpdatePublicationAsync(int publicationId, Publications updatedPublicationDetails);

        Task  DeletePublicationAsync(int publicationId);
    }
}

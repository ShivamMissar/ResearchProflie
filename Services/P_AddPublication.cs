using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ResearchProflie.Models;

namespace ResearchProflie.Services
{
    public class P_AddPublication : APublicationService
    {

        private readonly Appdatacontext _appdatacontext;



        public P_AddPublication(Appdatacontext appdatacontext)
        {
            _appdatacontext = appdatacontext;
        }

        public async Task<Publications> CreatePublicationAsync(Publications publication)
        {
            _appdatacontext.Add(publication);
            await _appdatacontext.SaveChangesAsync();

            return publication;
        }

       
       
        public async Task<List<Publications>> GetPublicationAsync()
        {
            return await _appdatacontext.Publications.ToListAsync();
        }

        public async Task<Publications> GetPublicationByIdAsync(int publicationId)
        {
            return await _appdatacontext.Publications.FindAsync(publicationId);
        }

        public async Task UpdatePublicationAsync(int publicationId, Publications updatedPublicationDetails)
        {
            var publication = await _appdatacontext.Publications.FindAsync(publicationId);

            if (publication != null)
            {
                // Update the properties of the existing publication with values from updatedPublication
                publication.PublicationTitle = updatedPublicationDetails.PublicationTitle;
                publication.PublicationDescription = updatedPublicationDetails.PublicationDescription;
                publication.PublicationDate = updatedPublicationDetails.PublicationDate;

                await _appdatacontext.SaveChangesAsync();
            }
        }

        public async Task DeletePublicationAsync(int publicationId)
        {

            var publication = await _appdatacontext.Publications.FindAsync(publicationId);
            if (publication != null)
            {
                _appdatacontext.Publications.Remove(publication);
                await _appdatacontext.SaveChangesAsync();
            }
        }       
    }
}


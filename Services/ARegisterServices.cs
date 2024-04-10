using Microsoft.AspNetCore.Identity;
using ResearchProflie.Models;

namespace ResearchProflie.Services
{
    public interface ARegisterServices
    {

        Task<IdentityResult> RegisterUserAsync(string firstname,string lastname, string email, string password,DateTime age,string address,string role);
        Task<bool>CheckRoleExistsAsync(string role);
        Task CreateRoleAsync(string role);

        Researcher CreateNewResearcher(string email, string firstname, string lastname, DateTime age, string address);
        Task<IdentityResult> CreateUserAsync(Researcher user, string password);

        Task AddUserToRole(Researcher user, string roleName);

      




    }
}

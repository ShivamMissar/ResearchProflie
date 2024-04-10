using Microsoft.AspNetCore.Identity;
using ResearchProflie.Models;

namespace ResearchProflie.Services
{
    public class P_Login : ILogin
    {
        private readonly SignInManager<Researcher> _signInManager;

        public P_Login(SignInManager<Researcher> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);

            return result.Succeeded;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}

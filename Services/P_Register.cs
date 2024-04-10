using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ResearchProflie.Models;
using System.Data;

namespace ResearchProflie.Services
{
    public class P_Register : IRegister
    {
        private readonly UserManager<Researcher> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public P_Register(UserManager<Researcher> userManager, RoleManager<IdentityRole> roleManager) 
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task AddUserToRole(Researcher user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task<bool> CheckRoleExistsAsync(string role)
        {
            return await _roleManager.RoleExistsAsync(role);
        }

        public Researcher CreateNewResearcher(string email, string firstname, string lastname, DateTime age, string address)
        {
            return new Researcher
            {
                UserName = email,
                Email = email,
                Firstname = firstname,
                Lastname = lastname,
                Age = age,
                address = address
            };
        }

        public async Task CreateRoleAsync(string role)
        {
            if (!await CheckRoleExistsAsync(role))
            {
                var identityRole = new IdentityRole { Name = role };
                var result = await _roleManager.CreateAsync(identityRole);
            }
        }

        public async Task<IdentityResult> CreateUserAsync(Researcher user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> RegisterUserAsync(string firstname, string lastname, string email, string password, DateTime age, string address, string role)
        {

            if (!await CheckRoleExistsAsync(role))
            {
                await CreateRoleAsync(role);
            }


            var user = CreateNewResearcher(email, firstname, lastname, age, address);

            var result = await CreateUserAsync(user, password);

            if (result.Succeeded)
            {
                await AddUserToRole(user, role); 
            }

            return result;
        }

        public string roleBasedOnEmail(string email)
        {
            if (email.Equals("admin@gmail.com"))
            {
                return "Admin";
            }
            else
            {
                return "Researcher";
            }
        }
        
    }
}

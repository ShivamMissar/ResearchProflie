namespace ResearchProflie.Services
{
    public interface ILogin
    {
        Task<bool> LoginAsync(string email, string password);
        Task LogoutAsync();
    }
}

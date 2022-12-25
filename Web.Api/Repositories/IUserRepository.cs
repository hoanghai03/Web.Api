using Web.Api.Models.Domain;

namespace Web.Api.Repositories
{
    public interface IUserRepository
    {
        Task<User> AuthenticateAsync(string username, string password); 
    }
}

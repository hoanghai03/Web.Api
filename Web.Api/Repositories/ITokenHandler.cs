using Web.Api.Models.Domain;

namespace Web.Api.Repositories
{
    public interface ITokenHandler
    {
        Task<string> GetTokenAsync(User user);
    }
}

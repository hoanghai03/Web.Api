using Web.Api.Models.Domain;

namespace Web.Api.Repositories
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Walk>> GetAllAsync();
    }
}

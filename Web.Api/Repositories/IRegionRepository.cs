using Web.Api.Models.Domain;

namespace Web.Api.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();
    }
}

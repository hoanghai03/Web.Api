using Web.Api.Models.Domain;

namespace Web.Api.Repositories
{
    public interface IRegionRepository
    {
        IEnumerable<Region> GetAll();
    }
}

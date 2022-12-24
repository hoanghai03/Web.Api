using Microsoft.EntityFrameworkCore;
using Web.Api.Data;
using Web.Api.Models.Domain;

namespace Web.Api.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        public NZWalksDbContext NZWalksDbContext { get; }
        public RegionRepository(NZWalksDbContext nZWalksDbContext)
        {
            NZWalksDbContext = nZWalksDbContext;
        }


        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await NZWalksDbContext.Regions.ToListAsync();
        }
    }
}

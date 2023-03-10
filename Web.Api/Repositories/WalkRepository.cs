using Microsoft.EntityFrameworkCore;
using Web.Api.Data;
using Web.Api.Models.Domain;

namespace Web.Api.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public WalkRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }
        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await nZWalksDbContext.Walks
                        .Include(x => x.Region)
                        .Include(x=>x.WalkDifficulty).ToListAsync();
        }
    }
}

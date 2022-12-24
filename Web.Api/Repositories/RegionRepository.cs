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

        public async Task<Region> GetAsync(Guid id)
        {
           var region = await NZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            return region;
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await NZWalksDbContext.AddAsync(region);
            await NZWalksDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = NZWalksDbContext.Regions.FirstOrDefault(item => item.Id == id);
            // if region is null => return null
            if(region == null)
            {
                return null;
            }
            // if region is not null 
            NZWalksDbContext.Regions.Remove(region);
            await NZWalksDbContext.SaveChangesAsync(true);
            return region;
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await NZWalksDbContext.Regions.FirstOrDefaultAsync(item => item.Id == id);
            if(region == null)
            {
                return null;
            }
            existingRegion.Area = region.Area;
            existingRegion.Code = region.Code;
            existingRegion.Lat = region.Lat;
            existingRegion.Name = region.Name;
            existingRegion.Long = region.Long;
            existingRegion.Population = region.Population;
            
            await NZWalksDbContext.SaveChangesAsync();
            return existingRegion; 

        }
    }
}

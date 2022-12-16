using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Supply_Chain_Portal.Data;
using Supply_Chain_Portal.Models.Domain;

namespace Supply_Chain_Portal.Repositories
{
    public class ResionRepository : IResionRepository
    {
        private readonly SupplyChainDbContext supplyChainDbContext;

        public ResionRepository(SupplyChainDbContext supplyChainDbContext)
        {
            this.supplyChainDbContext = supplyChainDbContext;
        }


        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await supplyChainDbContext.Regions
                //.Include(x=>x.walks)
                .ToListAsync();
        }

        public async Task<Region> GetRegionAsync(Guid Id)
        {
            var region = await supplyChainDbContext.Regions
                //.Include(x => x.walks)
                .FirstOrDefaultAsync(x => x.Id == Id);
                return region;

        }
        public async Task<Region> AddRegionDataAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await supplyChainDbContext.Regions.AddAsync(region);
            await supplyChainDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> UpdateRegionDataAsync(Guid Id, Region region)
        {
            var ExistingRegion = await supplyChainDbContext.Regions.FirstOrDefaultAsync(x => x.Id == Id);

            if (ExistingRegion == null)
            {
                return null;
            }
            ExistingRegion.Code = region.Code;
            ExistingRegion.Name = region.Name;
            ExistingRegion.Area = region.Area;
            ExistingRegion.Lat = region.Lat;
            ExistingRegion.Long = region.Long;
            ExistingRegion.Population = region.Population;
            await supplyChainDbContext.SaveChangesAsync();
            return ExistingRegion;
        }

        public async Task<Region> DeleteRegionDataAsync(Guid Id)
        {
            var region = await supplyChainDbContext.Regions.FirstOrDefaultAsync(x => x.Id == Id);
            if (region == null)
            {
                return region;
            }
            supplyChainDbContext.Regions.Remove(region);
            await supplyChainDbContext.SaveChangesAsync();
            return region;
        }
    }
}

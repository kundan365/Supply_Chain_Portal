using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Supply_Chain_Portal.Data;
using Supply_Chain_Portal.Models.Domain;
using System.Net.Http.Headers;

namespace Supply_Chain_Portal.Repositories
{
    
    public class WalkRepository:IWalkRepository
    {
        
        private readonly SupplyChainDbContext supplyChainDbContext;

        public WalkRepository(SupplyChainDbContext supplyChainDbContext)
        {
            this.supplyChainDbContext = supplyChainDbContext;
        }

        public async Task<IEnumerable<Walk>> GetWalksAsync()
        {
            var values= await supplyChainDbContext.Walks
                .Include(x=>x.Region)
                .Include(x=>x.WalkDifficulty)
                .ToListAsync();
            return values;
        }
        public async Task<Walk> GetWalkByIdAsync(Guid Id)
        {
            var walk = await supplyChainDbContext.Walks
            .Include(x => x.Region)
            .Include(x => x.WalkDifficulty).
            FirstOrDefaultAsync(x => x.Id == Id);
            return walk;                           
        }
       
        public async Task<Walk> AddWalksAsync(Walk walk)
        {
            walk.Id = Guid.NewGuid();
            await supplyChainDbContext.Walks.AddAsync(walk);
            await supplyChainDbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> UpdatewalksAsync(Guid Id, Walk walk)
        {
            var existWalkData=await supplyChainDbContext.Walks.FirstOrDefaultAsync(x => x.Id == Id); 
            if(existWalkData == null)
            {
                return walk;
            }
            existWalkData.Name = walk.Name;
            existWalkData.Length=walk.Length;
            existWalkData.RegionId=walk.RegionId;
            existWalkData.WalkDifficultyId=walk.WalkDifficultyId;
            await supplyChainDbContext.SaveChangesAsync();
            return existWalkData;


        }

        public async Task<Walk> DeletewalkAsync(Guid Id)
        {
            var walkdetails = await supplyChainDbContext.Walks.FirstOrDefaultAsync(x => x.Id == Id);
            if(walkdetails == null)
            {
                return walkdetails;
            }
            supplyChainDbContext.Walks.Remove(walkdetails);
            await supplyChainDbContext.SaveChangesAsync();
            return walkdetails;
        }
    }
}

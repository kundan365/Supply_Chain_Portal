using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Supply_Chain_Portal.Data;
using Supply_Chain_Portal.Models.Domain;

namespace Supply_Chain_Portal.Repositories
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly SupplyChainDbContext supplyChainDbContext;

        public WalkDifficultyRepository(SupplyChainDbContext supplyChainDbContext)
        {
            this.supplyChainDbContext = supplyChainDbContext;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetDifficultyAsync()
        {
            var value = await supplyChainDbContext.WalkDifficulty.ToListAsync();
            return value;
        }

        public async Task<WalkDifficulty> AddDifficultyAsync(WalkDifficulty walkDifficulty)
        {
            walkDifficulty.Id = Guid.NewGuid();
            await supplyChainDbContext.WalkDifficulty.AddAsync(walkDifficulty);
            await supplyChainDbContext.SaveChangesAsync();
            return walkDifficulty;
        }

        public async Task<WalkDifficulty> GetAllDifficultyAsync(Guid Id)
        {
            var walkdiff = await supplyChainDbContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == Id);
            return walkdiff;

        }

        public async Task<WalkDifficulty> DeleteDifficultyAsync(Guid Id)
        {
            var walkDiiff = await supplyChainDbContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == Id);
            if (walkDiiff == null)
            {
                return walkDiiff;
            }
            supplyChainDbContext.WalkDifficulty.Remove(walkDiiff);
            await supplyChainDbContext.SaveChangesAsync();
            return walkDiiff;
        }

        public async Task<WalkDifficulty> UpdatewalkDifficultyAsync(Guid Id, WalkDifficulty walkDifficulty)
        {
            var ExistingDifficulty = await supplyChainDbContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == Id);
            if (ExistingDifficulty == null)
            {
                return null;
            }
            ExistingDifficulty.Code = walkDifficulty.Code;
            await supplyChainDbContext.SaveChangesAsync();
            return ExistingDifficulty;
        }
    }
}

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
    }
}

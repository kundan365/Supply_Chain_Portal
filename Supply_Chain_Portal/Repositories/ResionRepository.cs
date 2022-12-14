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
            return await supplyChainDbContext.Regions.ToListAsync();
        }
    }
}

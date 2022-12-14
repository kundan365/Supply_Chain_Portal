using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Supply_Chain_Portal.Data;
using Supply_Chain_Portal.Models.Domain;

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
            var values= await supplyChainDbContext.Walks.ToListAsync();
            return values;
        }
    }
}

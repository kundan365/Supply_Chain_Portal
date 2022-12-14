using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Supply_Chain_Portal.Data;
using Supply_Chain_Portal.Models.Domain;

namespace Supply_Chain_Portal.Repositories
{
    public class ProductInfoRepository : IProductInfoRepository
    {
        private readonly SupplyChainDbContext supplyChainDbContext;

        public ProductInfoRepository(SupplyChainDbContext supplyChainDbContext)
        {
            this.supplyChainDbContext = supplyChainDbContext;
        }

        public async Task<IEnumerable<ProductDetails>> GetProductsDetailsAsync()
        {
            var result = await supplyChainDbContext.ProductInfo.ToListAsync();
            return result;
        }
    }
}

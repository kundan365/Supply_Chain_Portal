using Microsoft.EntityFrameworkCore.Infrastructure;
using Supply_Chain_Portal.Models.Domain;

namespace Supply_Chain_Portal.Repositories
{
    public interface IProductInfoRepository
    {
        Task<IEnumerable<ProductDetails>> GetProductsDetailsAsync();
    }
}

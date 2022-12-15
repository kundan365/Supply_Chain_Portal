using Microsoft.EntityFrameworkCore.Infrastructure;
using Supply_Chain_Portal.Models.Domain;

namespace Supply_Chain_Portal.Repositories
{
    public interface IProductInfoRepository
    {
        Task<IEnumerable<ProductDetails>> GetProductsDetailsAsync();
        Task<ProductDetails> GetAllProductAsync(int Id);
        Task<ProductDetails> AddProductDetailsAsync(ProductDetails productDetail);
        Task<ProductDetails> DeleteProductDetailsAsync(int Id); 
        Task<ProductDetails> UpdateProductDetailsAsync(int Id, ProductDetails productDetails);  


    }
}

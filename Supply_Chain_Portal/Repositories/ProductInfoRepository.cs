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
        public async Task<ProductDetails> GetAllProductAsync(int Id)
        {
            var Product = await supplyChainDbContext.ProductInfo.FirstOrDefaultAsync(x => x.Id == Id);
            return Product;
        }

        public async Task<ProductDetails> AddProductDetailsAsync(ProductDetails productDetail)
        {
            await supplyChainDbContext.ProductInfo.AddAsync(productDetail);
            await supplyChainDbContext.SaveChangesAsync();
            return productDetail;
        }

        public async Task<ProductDetails> DeleteProductDetailsAsync(int Id)
        {
            var product = await supplyChainDbContext.ProductInfo.FirstOrDefaultAsync(x => x.Id == Id);
            if (product == null)
            {
                return product;
            }
              supplyChainDbContext.ProductInfo.Remove(product);
            await supplyChainDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<ProductDetails> UpdateProductDetailsAsync(int Id, ProductDetails productDetails)
        {
            var ExistingProduct = await supplyChainDbContext.ProductInfo.FirstOrDefaultAsync(x => x.Id == Id);
            if (ExistingProduct == null)
            {
                return null;
            }
            ExistingProduct.PartNumber=productDetails.PartNumber;
            ExistingProduct.BoardNumber=productDetails.BoardNumber;
            ExistingProduct.ProductName=productDetails.ProductName;
            ExistingProduct.ProductType =productDetails.ProductType;
            ExistingProduct.Price=productDetails.Price;
            await supplyChainDbContext.SaveChangesAsync();
            return ExistingProduct;
        }
    }
}

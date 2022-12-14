using Microsoft.EntityFrameworkCore;
using Supply_Chain_Portal.Models.Domain;

namespace Supply_Chain_Portal.Data
{
    public class SupplyChainDbContext:DbContext
    {
        public SupplyChainDbContext(DbContextOptions<SupplyChainDbContext> options) : base(options)
        {

        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulty { get; set; }
        public DbSet<ProductDetails> ProductInfo { get; set; }

    }
}

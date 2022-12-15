using Supply_Chain_Portal.Models.Domain;

namespace Supply_Chain_Portal.Repositories
{
    public interface IResionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();
        Task<Region> GetRegionAsync(Guid Id);
        Task<Region>  AddRegionData(Region region); 
    }
}

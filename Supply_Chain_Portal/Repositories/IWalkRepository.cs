using Supply_Chain_Portal.Models.Domain;

namespace Supply_Chain_Portal.Repositories
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Walk>> GetWalksAsync();
        Task<Walk> GetWalkByIdAsync(Guid Id);
        Task<Walk> AddWalksAsync(Walk walk);
        Task<Walk> UpdatewalksAsync(Guid Id, Walk walk);
        Task<Walk> DeletewalkAsync(Guid Id);
    }
}

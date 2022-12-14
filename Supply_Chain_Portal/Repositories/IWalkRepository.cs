using Supply_Chain_Portal.Models.Domain;

namespace Supply_Chain_Portal.Repositories
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Walk>> GetWalksAsync();

    }
}

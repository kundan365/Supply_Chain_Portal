using Supply_Chain_Portal.Models.Domain;

namespace Supply_Chain_Portal.Repositories
{
    public interface IWalkDifficultyRepository
    {
        Task<IEnumerable<WalkDifficulty>> GetDifficultyAsync();
        Task<WalkDifficulty> GetAllDifficultyAsync(Guid Id);
        Task<WalkDifficulty> AddDifficultyAsync(WalkDifficulty walkDifficulty);
    }
}

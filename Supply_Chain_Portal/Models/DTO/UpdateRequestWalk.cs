namespace Supply_Chain_Portal.Models.DTO
{
    public class UpdateRequestWalk
    {
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid WalkDifficultyId { get; set; }
        public Guid RegionId { get; set; }
    }
}

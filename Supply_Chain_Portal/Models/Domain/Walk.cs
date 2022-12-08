namespace Supply_Chain_Portal.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Lenght { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDefaultyId { get; set; }
        //Navigation Property
        public Region Region { get; set; }
        public WalkDifficulty WalkDifficulty { get; set; }
    }
}

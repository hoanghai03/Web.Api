using Web.Api.Models.Domain;

namespace Web.Api.Models.DTO
{
    public class WalkDto
    {
        public Guid Id { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public Region Region { get; set; }
        public WalkDifficulty WalkDifficulty { get; set; }
    }
}

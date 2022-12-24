using AutoMapper;
using Web.Api.Models.Domain;
using Web.Api.Models.DTO;

namespace Web.Api.Profiles
{
    public class WalkProfiles : Profile
    {
        public WalkProfiles() { 
            CreateMap<Walk,WalkDto>().ReverseMap();
            CreateMap<WalkDifficulty,WalkDifficultyDto>().ReverseMap();
        }
    }
}

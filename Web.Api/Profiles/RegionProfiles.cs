using AutoMapper;
using Web.Api.Models.Domain;
using Web.Api.Models.DTO;

namespace Web.Api.Profiles
{
    public class RegionProfiles : Profile
    {
        public RegionProfiles()
        {
            CreateMap<Region, RegionDto>().ForMember(dest => dest.RegionId, options => options.MapFrom(src => src.Id)).ReverseMap();
        }
    }
}

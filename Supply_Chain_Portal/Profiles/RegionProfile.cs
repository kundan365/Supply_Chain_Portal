using AutoMapper;

namespace Supply_Chain_Portal.Profiles
{
    public class RegionProfile:Profile
    {
        public RegionProfile()
        {
            CreateMap<Models.Domain.Region, Models.DTO.Region>().ReverseMap();
            
        }
    }
}

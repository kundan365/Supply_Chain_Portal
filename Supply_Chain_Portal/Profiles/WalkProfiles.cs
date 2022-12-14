using AutoMapper;

namespace Supply_Chain_Portal.Profiles
{
    public class WalkProfiles:Profile
    {
        public WalkProfiles()
        {
            CreateMap<Models.Domain.Walk,Models.DTO.Walk>().ReverseMap();
        }
    }
}

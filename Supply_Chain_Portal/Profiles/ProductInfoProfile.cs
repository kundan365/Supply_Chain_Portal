using AutoMapper;
using Microsoft.Extensions.Options;

namespace Supply_Chain_Portal.Profiles
{
    public class ProductInfoProfile:Profile
    {
        public ProductInfoProfile()
        {
            CreateMap<Models.Domain.ProductDetails, Models.DTO.ProductDetails>().ReverseMap();
            //if different Id property name of both models are different then add below
                //.ForMember(dest=>dest.Id,Options=>Options.MapFrom(src=>src.Id));
            
        }
    }
}

using AutoMapper;
using webapi.Models;

namespace webapi.Data.Configurations
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            CreateMap<RestaurantModel, RestaurantVM>().ReverseMap();
            CreateMap<RestaurantCreateVM, RestaurantModel>().ReverseMap();
            CreateMap<UserModel, UserVM>().ReverseMap();
            CreateMap<UserModel, CreatorVM>().ReverseMap();
            CreateMap<RestaurantModel, RestaurantVM>()
                .ForMember(dest => dest.Creator, opt => opt.MapFrom(src => src.Creator));

        }
    }
}

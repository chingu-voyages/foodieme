using AutoMapper;
using webapi.Models;

namespace webapi.Data.Configurations
{
    public class MapperConfig : Profile
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MapperConfig()
        {
            //this.context = context;
            //Make sure the mappers check if the restaurant exists
            CreateMap<MealRequestCreateVM, MealRequestModel>()
                // Mapper expects an Expression body (x => x.someProp) inside MapFrom instead of a statement body (x => {})
                //.ForMember(dest => dest.Restaurant, opt => opt.MapFrom(src =>
                //{
                //    var restaurant = context.Restaurants.FirstOrDefault(r => r.Id == src.RestaurantId);
                //    //if (restaurant == null)
                //    //{
                //    //    return null;
                //    //}
                //    return restaurant;
                //}))
                //.ForMember(dest => dest.Restaurant, opt =>
                //{
                //    opt.Condition(src => src.RestaurantId != 0);
                //    opt.MapFrom(src => context!.Restaurants.FirstOrDefault(r => r.Id == src.RestaurantId));
                //})
                .ReverseMap();
            CreateMap<RestaurantModel, RestaurantVM>().ReverseMap();
            CreateMap<RestaurantCreateVM, RestaurantModel>().ReverseMap();
            CreateMap<UserModel, CreatorVM>().ReverseMap();
            CreateMap<UserModel, UserVM>()
                .ForMember(dest => dest.CreatedMealRequests, opt => opt.MapFrom(src => src.CreatedMealRequests))
                .ForMember(dest => dest.CreatedRestaurants, opt => opt.MapFrom(src => src.CreatedRestaurants))
                .AfterMap((src, dest, context) =>
                {
                    dest.CreatedMealRequests = context.Mapper.Map<List<MealRequestVM>>(src.CreatedMealRequests);
                    dest.CreatedRestaurants = context.Mapper.Map<List<RestaurantVM>>(src.CreatedRestaurants);
                })
                .ReverseMap();
            CreateMap<RestaurantModel, RestaurantVM>()
                .ForMember(dest => dest.Creator, opt => opt.MapFrom(src => src.Creator));
            CreateMap<MealRequestModel, MealRequestVM>()
                .ForMember(dest => dest.CreatorName, opt => opt.MapFrom(src => src.Creator.UserName))
                .ForMember(dest => dest.CompanionsNames, opt => opt.MapFrom(src => src.Companions!.Select(c => c.UserName!).ToList()))
                .ForMember(dest => dest.CompanionsId, opt => opt.MapFrom(src => src.Companions!.Select(c => c.Id!).ToList()))
                //enables nested mapping for different models
                .AfterMap((src, dest, context) =>
                {
                    dest.Creator = context.Mapper.Map<CreatorVM>(src.Creator);
                    dest.Restaurant = context.Mapper.Map<RestaurantVM>(src.Restaurant);
                })
                .ReverseMap();

        }
    }
}

using webapi.Models;

namespace webapi.Interfaces
{
    public interface IRestaurantService: IGenericService<RestaurantModel>
    {
        Task<List<RestaurantVM>> GetAllRestaurantsWithCreator();
        Task<List<RestaurantVM>> GetAllRestaurants();
        Task<RestaurantVM> GetRestaurant(int id);
        Task<RestaurantVM> CreateRestaurant(RestaurantCreateVM model);
        Task<bool> DeleteRestaurant(int id);

    }
}

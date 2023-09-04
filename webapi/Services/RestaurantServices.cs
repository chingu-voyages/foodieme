using AutoMapper;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Services
{
    public class RestaurantServices: GenericServices<RestaurantModel>, IRestaurantService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public RestaurantServices(ApplicationDbContext _context,IMapper mapper): base(_context)
        {
            this.context = _context;
            this.mapper = mapper;
        }

        public async Task<List<RestaurantVM>> GetAllRestaurantsWithCreator() {
            var restaurants = await context.Restaurants.Include(r => r.Creator).ToListAsync();
            var restaurantVM = mapper.Map<List<RestaurantVM>>(restaurants);
            return restaurantVM;
        }       
        public async Task<List<RestaurantVM>> GetAllRestaurants() {
            //var restaurants = await context.Restaurants.ToListAsync();
            var restaurantVM = mapper.Map<List<RestaurantVM>>(await GetAllAsync());
            return restaurantVM;
        }

        public async Task<RestaurantVM> GetRestaurant(int id)
        {
             if (context.Restaurants == null)
          {
              return null;
          }
            var restaurantModel = await context.Restaurants
                .Include(r => r.Creator)
                .FirstOrDefaultAsync(q =>  q.Id == id);
            var restaurantVM = mapper.Map<RestaurantVM>(restaurantModel);

            if (restaurantVM == null)
            {
                return null;
            }

            return restaurantVM;
        }

    }
}

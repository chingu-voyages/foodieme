﻿using AutoMapper;
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

        public async Task<RestaurantVM?> GetRestaurant(int id)
        {
             if (context.Restaurants == null)
          {
              return null;
          }
            var restaurantModel = await context.Restaurants
                .Include(r => r.Creator)
                .Include(r => r.MealRequests)
                    .ThenInclude(mr => mr.Creator)
                .FirstOrDefaultAsync(q =>  q.Id == id);
            var restaurantVM = mapper.Map<RestaurantVM>(restaurantModel);

            if (restaurantVM == null)
            {
                return null;
            }

            return restaurantVM;
        }
        public async Task<MealRequestVM?> GetRestaurantMealRequests(int id)
        {
             if (context.Restaurants == null)
          {
              return null;
          }
            var restaurantMealRequests = await context.MealRequests
                .Include(r => r.Restaurant)
                .FirstOrDefaultAsync(mr =>  mr.Restaurant.Id == id);
            var restaurantVM = mapper.Map<MealRequestVM>(restaurantMealRequests);

            if (restaurantVM == null)
            {
                return null;
            }

            return restaurantVM;
        }

        public async Task<RestaurantVM> CreateRestaurant(RestaurantCreateVM model)
        {
            //Check if model is properly built
            var restaurantModel = mapper.Map<RestaurantModel>(model);
            var newRestaurant = await AddAsync(restaurantModel);
            var newRestaurantVM = mapper.Map<RestaurantVM>(newRestaurant);
            return newRestaurantVM;
        }

        public async Task<bool> DeleteRestaurant(int id)
        {
          
            var isDelete = await DeleteAsync(id);
            if (isDelete == false) return false;
            return true;
        }

        public async Task<RestaurantVM> EditRestaurant(RestaurantVM model)
        {
            var restaurantModel = mapper.Map<RestaurantModel>(model);
            await UpdateAsync(restaurantModel);
            return mapper.Map<RestaurantVM>(restaurantModel);

        }
    }
}

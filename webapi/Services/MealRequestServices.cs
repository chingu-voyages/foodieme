using AutoMapper;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Interfaces;
using webapi.Models;
using webapi.Services.Utils;

namespace webapi.Services
{
    public class MealRequestServices : GenericServices<MealRequestModel>, IMealRequestService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MealRequestServices(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<MealRequestVM> CreateMealRequest(MealRequestCreateVM vm)
        {
            // Check is restaurant exists?
            var restaurant = context.Restaurants.FirstOrDefault(r => r.Id == vm.RestaurantId);
            if (restaurant == null)
            {
                throw new Exception("Restaurant does not exist");
            }

            // find creator, find restaurant
            var creator = await context.Users.FindAsync(vm.CreatorId);
            Console.WriteLine("Found creator");
            var newMealReqModel = new MealRequestModel
            {
                CreatorId = vm.CreatorId,
                Creator = creator,
                Restaurant = restaurant,
                NumberOfPeople = vm.NumberOfPeople,
                DateTime = vm.DateTime,

            };
            var newMealReq = await AddAsync(newMealReqModel);
            Console.WriteLine("Added meal request");
            //ObjectLogger.LogObject(newMealReq);
            //ObjectLogger.LogObject(newMealReq.Creator);
            //ObjectLogger.LogObject(newMealReq.Restaurant);
            try
            {
                var newMealReqVM = mapper.Map<MealRequestVM>(newMealReq);
                Console.WriteLine("mapped back to MeaRequestVM");
                //newMealReqVM.Creator = mapper.Map<CreatorVM>(newMealReq.Creator);
                //newMealReqVM.Restaurant = mapper.Map<RestaurantVM>(newMealReq.Restaurant);
                ObjectLogger.LogObject(newMealReqVM);
                return newMealReqVM;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

        }

        public async Task<List<MealRequestVM>> GetAllMealRequests(string userId)
        {
            var userModel = await context.Users.FindAsync(userId);
            if (userModel == null)
            {
                return null;
            }
            var mealRequestsList = new List<MealRequestModel>();
            // if admin, get all
            if (userModel.UserName == "admin" && userModel.Email == "admin@foodieme.ca")
            {
            mealRequestsList = await context.MealRequests
                .Include(mr => mr.Creator)
                .Include(mr => mr.Restaurant)
                .ToListAsync();
            } else
            {
                mealRequestsList = await context.MealRequests
                .Include(mr => mr.Creator)
                .Include(mr => mr.Restaurant)
                .Where(mr => mr.Creator.Id == userId)
                .ToListAsync();
            }
            var mealRequestsListVM = mapper.Map<List<MealRequestVM>>(mealRequestsList);
            return mealRequestsListVM;
        }

        public async Task<MealRequestVM?> JoinMealRequest(int id, string userId)
        {
            var mealRequestModel = context.MealRequests.FirstOrDefault(mr => mr.Id == id);
            if (mealRequestModel == null)
            {
                return null;
            }
            var userToAdd = context.Users.FirstOrDefault(user => user.Id == userId);
            if (userToAdd == null)
            {
                return null;
            }
            mealRequestModel?.Companions?.Add(userToAdd);

            await UpdateAsync(mealRequestModel!);

            var mrVM = mapper.Map<MealRequestVM>(mealRequestModel);

            return mrVM;
        }

        public async Task<MealRequestVM?> LeaveMealRequest(int id, string userId)
        {
            var mealRequestModel = context.MealRequests.FirstOrDefault(mr => mr.Id == id);
            if (mealRequestModel == null)
            {
                return null;
            }
            var userToRemove = context.Users.FirstOrDefault(user => user.Id == userId);
            if (userToRemove == null)
            {
                return null;
            }
            mealRequestModel?.Companions?.Remove(userToRemove);

            await UpdateAsync(mealRequestModel!);

            var mrVM = mapper.Map<MealRequestVM>(mealRequestModel);

            return mrVM;
        }

        public async Task<MealRequestVM?> UpdateMealRequest(MealRequestVM model)
        {
            var mealrequestModel = await GetAsync(model.Id);
            if (mealrequestModel == null)
            {
                return null;
            }

            // full modify
            //mealrequestModel = model;

            var updatedModel = mapper.Map<MealRequestModel>(model);

            await UpdateAsync(updatedModel);

            var updatedVM = mapper.Map<MealRequestVM>(updatedModel);

            return updatedVM;
        }
    }
}

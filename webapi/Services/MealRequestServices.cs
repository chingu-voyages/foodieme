using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using webapi.Constants;
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
        private readonly AutoMapper.IConfigurationProvider mapperconfig;

        public MealRequestServices(ApplicationDbContext context,
            IMapper mapper,
            AutoMapper.IConfigurationProvider mapperconfig
            ) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
            this.mapperconfig = mapperconfig;
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
            try
            {
                var newMealReqVM = mapper.Map<MealRequestVM>(newMealReq);
                Console.WriteLine("mapped back to MeaRequestVM");
                ObjectLogger.LogObject(newMealReqVM);
                return newMealReqVM;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

        }

        public async Task<List<MealRequestVM>> GetAllMealRequests()
        {
            var mealRequestsList = await context.MealRequests
                .Include(mr => mr.Creator)
                .Include(mr => mr.Restaurant)
                .ProjectTo<MealRequestVM>(mapperconfig)
                .ToListAsync();

            return mealRequestsList;
        }



        public async Task<List<MealRequestVM>> GetAllMyMealRequests(string userId)
        {
            var userModel = await context.Users.FindAsync(userId);
            if (userModel == null)
            {
                return null;
            }
            var mealRequestsList = new List<MealRequestVM>();
            // if admin, get all
            if (userModel.UserName == "admin" && userModel.Email == "admin@foodieme.ca")
            {
                Console.WriteLine($"admin here");
                mealRequestsList = await context.MealRequests
                    .Include(mr => mr.Creator)
                    .Include(mr => mr.Restaurant)
                    .ProjectTo<MealRequestVM>(mapperconfig)
                    .ToListAsync();
            }
            else
            {
                Console.WriteLine($"Not admin here");
                mealRequestsList = await context.MealRequests
                .Include(mr => mr.Creator)
                .Include(mr => mr.Restaurant)
                .Where(mr => mr.Creator.Id == userId)
                .ProjectTo<MealRequestVM>(mapperconfig)
                .ToListAsync();
            }
            //Not needed as added mapper config
            //var mealRequestsListVM = mapper.Map<List<MealRequestVM>>(mealRequestsList);
            return mealRequestsList;
        }

        public async Task<MealRequestVM?> GetMealRequest(int id)
        {
            //var mealRequest = await GetAsync(id);
            var mealRequest = await context.MealRequests
                .Include(mr => mr.Creator)
                .Include(mr => mr.Restaurant)
                .Include(mr => mr.Companions)
                //.Where(mr => mr.Id == id)
                .ProjectTo<MealRequestVM>(mapperconfig)
                .FirstOrDefaultAsync(mr => mr.Id == id);
            //return mapper.Map<MealRequestVM>(mealRequest);

            return mealRequest;
        }

        public async Task<MealRequestVM?> EditParticipation(int id, string userId)
        {
            var mealRequestModel = context.MealRequests
                .Include(mr => mr.Companions)
                .FirstOrDefault(mr => mr.Id == id);
            Console.WriteLine("Logging object");
            //ObjectLogger.LogObject(mealRequestModel);
            ObjectLogger.LogObject(mealRequestModel.Companions);
            if (mealRequestModel == null)
            {
                return null;
            }
            var currentUser = context.Users.FirstOrDefault(user => user.Id == userId);
            if (currentUser == null)
            {
                return null;
            }
            if (mealRequestModel.Companions!.Any(companion => companion.Id == currentUser.Id))
            {
                Console.WriteLine($"removing companion");
                mealRequestModel?.Companions?.RemoveAll(c => c.Id == currentUser.Id);
            }
            else
            {
                if (mealRequestModel.Companions?.Count < mealRequestModel.NumberOfPeople)
                {
                    Console.WriteLine($"adding companion");
                    mealRequestModel?.Companions?.Add(currentUser);
                }

                else
                {
                    throw new Exception("Meal Request is full");
                }
            }

            await UpdateAsync(mealRequestModel!);

            var mrVM = mapper.Map<MealRequestVM>(mealRequestModel);

            return mrVM;
        }

        public async Task<MealRequestVM?> UpdateMealRequest(MealRequestVM model, int id)
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

        public async Task<bool> DeleteMealRequest(int id, string userId)
        {
            var mealRequest = await context.MealRequests
               .Include(mr => mr.Creator)
               .FirstOrDefaultAsync(mr => mr.Id == id);

            // TODO: also allow admin to delete the MR

            if (mealRequest == null || (mealRequest.Creator.Id != userId && userId != Admin.AdminUserId))
            {
                return false;
            }

            return true;
        }
    }
}

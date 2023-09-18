using AutoMapper;
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

        public async Task<List<MealRequestVM>> GetAllMealRequests()
        {
            var mealRequestsList = await context.MealRequests
                .Include(mr => mr.Creator)
                .Include(mr => mr.Restaurant)
                .ToListAsync();
            var mealRequestsListVM = mapper.Map<List<MealRequestVM>>(mealRequestsList);
            return mealRequestsListVM;
        }

        public Task<MealRequestVM> JoinMealRequest(string id)
        {
            throw new NotImplementedException();
        }

        public Task<MealRequestVM> LeaveMealRequest(string id)
        {
            throw new NotImplementedException();
        }
    }
}

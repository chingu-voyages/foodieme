using webapi.Data;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Services
{
    public class MealRequestServices : GenericServices<MealRequestModel>, IMealRequestService
    {
        private readonly ApplicationDbContext context;

        public MealRequestServices (ApplicationDbContext context): base(context)
        {
            this.context = context;
        }

        public Task<MealRequestVM> CreateMealRequest(MealRequestCreateVM vm)
        {
            throw new NotImplementedException();
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

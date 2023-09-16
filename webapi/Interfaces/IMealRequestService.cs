using webapi.Models;

namespace webapi.Interfaces
{
    public interface IMealRequestService
    {
        Task<MealRequestVM> CreateMealRequest(MealRequestCreateVM vm);
        Task<MealRequestVM> JoinMealRequest(string id);
        Task<MealRequestVM> LeaveMealRequest(string id);

    }
}

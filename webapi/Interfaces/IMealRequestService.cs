using webapi.Models;

namespace webapi.Interfaces
{
    public interface IMealRequestService: IGenericService<MealRequestModel>
    {
        Task<MealRequestVM> CreateMealRequest(MealRequestCreateVM vm);
        Task<MealRequestVM> JoinMealRequest(string id);
        Task<MealRequestVM> LeaveMealRequest(string id);
        Task<List<MealRequestVM>> GetAllMealRequests();

    }
}

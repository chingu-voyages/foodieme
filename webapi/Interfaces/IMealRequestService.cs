using webapi.Models;

namespace webapi.Interfaces
{
    public interface IMealRequestService: IGenericService<MealRequestModel>
    {
        Task<MealRequestVM> CreateMealRequest(MealRequestCreateVM vm);
        Task<MealRequestVM?> JoinMealRequest(int id, string userId);
        Task<MealRequestVM?> LeaveMealRequest(int id, string userId);
        Task<MealRequestVM?> UpdateMealRequest(MealRequestVM model);
        Task<List<MealRequestVM>> GetAllMealRequests(string userId);
        //Task<List<MealRequestVM>> GetAllMyMealRequests();

    }
}

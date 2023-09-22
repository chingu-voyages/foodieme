using webapi.Models;

namespace webapi.Interfaces
{
    public interface IMealRequestService: IGenericService<MealRequestModel>
    {
        Task<MealRequestVM> CreateMealRequest(MealRequestCreateVM vm);
        Task<MealRequestVM?> EditParticipation(int id, string userId);
        //Task<MealRequestVM?> LeaveMealRequest(int id, string userId);
        Task<MealRequestVM?> UpdateMealRequest(MealRequestVM model, int id);
        Task<List<MealRequestVM>> GetAllMyMealRequests(string userId);
        Task<MealRequestVM?> GetMealRequest(int id);
        //Task<List<MealRequestVM>> GetAllMyMealRequests();
        Task<bool> DeleteMealRequest(int id, string userId);

    }
}

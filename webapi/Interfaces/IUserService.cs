using webapi.Models;

namespace webapi.Interfaces
{
    public interface IUserService: IGenericService<UserModel>
    {
        Task<List<UserVM>> GetAllUsers();
        Task<UserVM> GetUser(string id);

    }
}

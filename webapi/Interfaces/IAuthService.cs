using webapi.Models;

namespace webapi.Interfaces
{
    public interface IAuthService: IGenericService<UserModel>
    {
        Task<UserModel> LoginUser(UserLoginModel userModel);
        Task<UserModel> RegisterNewUser(UserRegister model);
        Task<bool> LogoutUser();
        

    }
}

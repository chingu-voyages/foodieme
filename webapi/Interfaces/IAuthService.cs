using webapi.Models;

namespace webapi.Interfaces
{
    public interface IAuthService: IGenericService<UserModel>
    {
        Task<LoginResponse> LoginUser(UserLoginModel userModel);
        Task<UserModel> RegisterNewUser(UserRegister model);
        string LogoutUser();
        

    }
}

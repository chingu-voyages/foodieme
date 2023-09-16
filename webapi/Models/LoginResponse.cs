namespace webapi.Models
{
    public class LoginResponse
    {
        public string token { get; set; }
        public UserModel user { get; set; }
    }
}

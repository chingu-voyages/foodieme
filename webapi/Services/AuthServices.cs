using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using webapi.Data;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Services
{
    public class AuthServices: GenericServices<UserModel>, IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public AuthServices(IConfiguration configuration, ApplicationDbContext context): base(context)
        {
            this._configuration = configuration;
            this._context = context;
        }


        internal string CreateToken(UserModel userModel)
        {
            Console.WriteLine($"userModel.Email {userModel.Email}");
            List<Claim> claims = new()
            {
                new Claim("name", userModel.UserName),
                new Claim(ClaimTypes.Email, userModel.Email),
                new Claim("email", userModel.Email),
                new Claim("sub", userModel.Id),
            };

            // Key used to create the JWT and verify the JWT, whenever user's make a call.
            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            //Need a signin credentials
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims: claims,
                expires: DateTime.Now.AddHours(12),
                signingCredentials: creds
                );

            //write token
            var jwt = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return jwt;
        }

        public async Task<string> LoginUser(UserLoginModel model)
        {
            string email = model.email;
            string password = model.password;
            System.Diagnostics.Debug.WriteLine($"Login {email}");
            System.Diagnostics.Debug.WriteLine($"Password {password}");
            Console.WriteLine($"Login {email}");
            Console.WriteLine($"Password {password}");
            var user = await _context.Users.FirstOrDefaultAsync(user => email == user.Email);
            if ( user == null )
            {
                return null;
            }
            var hasher = new PasswordHasher<UserModel>();
            if (PasswordVerificationResult.Failed == hasher.VerifyHashedPassword(user, user.PasswordHash, password))
            {
                return null;
            }
            string token = CreateToken(user);

            return token;
        }

        public Task<bool> LogoutUser()
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> RegisterNewUser(UserRegister model)
        {
            var userExist = await _context.Users.AnyAsync(user => model.Email == user.Email);
            if (userExist)
            {
                return null;
            }
            var hasher = new PasswordHasher<UserModel>();
            var userModel = new UserModel
            {
                PasswordHash = hasher.HashPassword(null, model.Password),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.UserName,
                DateJoined = DateTime.Now,
                DateOfBirth = (DateTime)model.DateOfBirth

            };

            await AddAsync(userModel);

            return userModel;

        }
    }
}

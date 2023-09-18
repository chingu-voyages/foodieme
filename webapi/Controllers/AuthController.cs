using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using webapi.Data;
using webapi.Interfaces;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;

        //to access the appsettings.json
        private readonly IConfiguration _configuration;
        private readonly IAuthService authServices;

        //private readonly GenericServices<UserModel> genericServices;

        //private readonly AuthServices authServices;

        //For testing purposes
        //public static UserModel newUserModel = new UserModel();

        public AuthController(ApplicationDbContext context,
            UserManager<UserModel> userManager,
            SignInManager<UserModel> signInManager,
            IConfiguration configuration,
            IAuthService authServices
            )
        {
            _context = context;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._configuration = configuration;
            this.authServices = authServices;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserModel>> Register([FromBody] UserRegister userRegister)
        {
            Console.WriteLine("Model state: " + ModelState);
            Console.WriteLine("Model state is valid: " + ModelState.IsValid);

            // Log the model data
            Console.WriteLine($"UserName: {userRegister.UserName}");
            Console.WriteLine($"Email: {userRegister.Email}");

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid form");
            }

            // manual checking for now
            //if (string.IsNullOrEmpty(userRegister.UserName) ||
            //    string.IsNullOrEmpty(userRegister.Password) ||
            //    string.IsNullOrEmpty(userRegister.Email)
            //{
            //    return BadRequest("Invalid form");
            //}

            var newUser = await authServices.RegisterNewUser(userRegister);
            if (newUser == null)
            {
                return BadRequest("A user with this email address already exist");
            }
            return Created("somewhere", newUser);

        }

        [HttpPost("login")]
        public async Task<ActionResult<UserModel>> Login([FromBody] UserLoginModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid form");
            }

            var loginRes = await authServices.LoginUser(model);
            if (loginRes.token == null)
            {
                return BadRequest("Login Information does not match our records");
            }

            return Ok(new { token = loginRes.token });

        }


        [HttpGet]
        [Authorize]
        public ActionResult<string> GetUserName()
        {
            var username = User.FindFirst("name").Value!;
            //Console.WriteLine($"username {username}");

            var userId = User.FindFirst("sub").Value!;
            //Console.WriteLine($"userId {userId}");

            var userEmailClaim = User.FindFirst("email");
            //var userEmail = User.FindFirst("email").Value;
            //Console.WriteLine($"userEmailClaim {userEmailClaim}");

            var userEmail = User.FindFirst(ClaimTypes.Email).Value;
            //Console.WriteLine($"userEmail {userEmail}");

            return Ok(new
            {
                username,
                userId,
                userEmail,
                //userEmailClaim
            });
        }

        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            var expiredToken = authServices.LogoutUser();

            _signInManager.SignOutAsync();

            // You can optionally include any additional response data or messages.
            return Ok(new { message = "Logged out successfully", token = expiredToken });
        }

    }
}

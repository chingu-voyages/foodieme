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
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;

        //to access the appsettings.json
        private readonly IConfiguration _configuration;
        private readonly AuthServices authServices;

        //private readonly GenericServices<UserModel> genericServices;

        //private readonly AuthServices authServices;

        //For testing purposes
        public static UserModel newUserModel = new UserModel();

        public AuthController(ApplicationDbContext context,
            UserManager<UserModel> userManager,
            SignInManager<UserModel> signInManager,
            IConfiguration configuration,
            AuthServices authServices
            )
        {
            _context = context;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._configuration = configuration;
            this.authServices = authServices;
            //this.genericServices = genericServices;
            //this.authServices = authServices;
        }

        public class UserLoginModel
        {
            public string email { get; set; }
            public string password { get; set; }
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserModel>> Register(UserRegister userRegister)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid form");
            }

            var newUser = await authServices.RegisterNewUser(userRegister);
            //var userExist = await _context.Users.AnyAsync(user => userRegister.Email == user.Email);
            //System.Diagnostics.Debug.WriteLine("result from context");
            //System.Diagnostics.Debug.WriteLine(userExist);

            //var result = await _userManager.FindByEmailAsync(userRegister.Email);
            //System.Diagnostics.Debug.WriteLine("result from user manager");
            //System.Diagnostics.Debug.WriteLine(result);
            if (newUser == null)
            {
                return BadRequest("A user with this email address already exist");
            }

            //var hasher = new PasswordHasher<UserModel>();
            //var userModel = new UserModel
            //{
            //    PasswordHash = hasher.HashPassword(null, userRegister.Password),
            //    FirstName = userRegister.FirstName,
            //    LastName = userRegister.LastName,
            //    Email = userRegister.Email,
            //    UserName = userRegister.UserName,
            //    DateJoined = DateTime.Now,
            //    DateOfBirth = (DateTime)userRegister.DateOfBirth

            //};

            //await _context.Users.AddAsync(userModel);
            //await _context.SaveChangesAsync();
            //newUserModel.PasswordHash = hasher.HashPassword(null, userRegister.Password);
            //newUserModel.FirstName = userRegister.FirstName;
            //newUserModel.LastName = userRegister.LastName;
            //newUserModel.Email = userRegister.Email;
            //newUserModel.UserName = userRegister.UserName;
            //newUserModel.DateJoined = DateTime.Now;
            //newUserModel.DateOfBirth = (DateTime)userRegister.DateOfBirth;
            //return CreatedAtAction("Registration"; newUser);
            //return Ok(newUser);
            return Created("somewhere", newUser);

        }

        [HttpPost("login")]
        public async Task<ActionResult<UserModel>> Login([FromBody] UserLoginModel model)
        {

            string email = model.email;
            string password = model.password;
            System.Diagnostics.Debug.WriteLine($"Login {email}");
            System.Diagnostics.Debug.WriteLine($"Password {password}");
            Console.WriteLine($"Login {email}");
            Console.WriteLine($"Password {password}");
            var userExist = await _context.Users.FirstOrDefaultAsync(user => email == user.Email);
            if (userExist == null || userExist.Email != email)
            {
                return BadRequest("Login Information does not match our records");
            }
            var hasher = new PasswordHasher<UserModel>();
            if (PasswordVerificationResult.Failed == hasher.VerifyHashedPassword(userExist, userExist.PasswordHash, password))
            {
                return BadRequest("Login Information does not match our records");

            }
            //var some = await _userManager.
            //var something = await _signInManager.PasswordSignInAsync(userExist.Email, model.password, false, false);
            //something.Succeeded
            //Send JWTToken
            //return CreatedAtAction("Registration", newUser);
            //return Ok(newUser);
            string token = CreateToken(userExist);

            return Ok(token);

        }

        //[HttpPost]
        //public Task<ActionResult> Logout()
        //{
        //    return Ok();
        //}

        private string CreateToken(UserModel userModel)
        {
            //var token = "";
            Console.WriteLine($"userModel.Email {userModel.Email}");
            //Console.WriteLine($"key {key}");
            //Console.WriteLine($"key {key}");
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

            foreach (var claim in claims)
            {
                Console.WriteLine($"claims {claim}");

            }

            //Need a singin credentials
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims: claims,
                expires: DateTime.Now.AddHours(12),
                //expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            //write token
            var jwt = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return jwt;
        }


        [HttpGet, Authorize]
        public ActionResult<string> GetUserName()
        {
            var username = User.FindFirst("name").Value!;
            Console.WriteLine($"username {username}");

            var userId = User.FindFirst("sub").Value!;
            Console.WriteLine($"userId {userId}");

            var userEmailClaim = User.FindFirst("email");
            //var userEmail = User.FindFirst("email").Value;
            Console.WriteLine($"userEmailClaim {userEmailClaim}");

            var userEmail = User.FindFirst(ClaimTypes.Email).Value;
            Console.WriteLine($"userEmail {userEmail}");

            return Ok(new
            {
                username,
                userId,
                userEmail,
                //userEmailClaim
            });
        }

        //// GET: UserVMs
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Users.ToListAsync());
        //}

        //// GET: UserVMs/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.UserVM == null)
        //    {
        //        return NotFound();
        //    }

        //    var userVM = await _context.UserVM
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (userVM == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(userVM);
        //}

        //// GET: UserVMs/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: UserVMs/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,UserName,Email,BudgetMin,BudgetMax,Picture,DateOfBirth,DateJoined")] UserVM userVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(userVM);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(userVM);
        //}

        //// GET: UserVMs/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.UserVM == null)
        //    {
        //        return NotFound();
        //    }

        //    var userVM = await _context.UserVM.FindAsync(id);
        //    if (userVM == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(userVM);
        //}

        //// POST: UserVMs/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Email,BudgetMin,BudgetMax,Picture,DateOfBirth,DateJoined")] UserVM userVM)
        //{
        //    if (id != userVM.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(userVM);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UserVMExists(userVM.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(userVM);
        //}

        //// GET: UserVMs/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.UserVM == null)
        //    {
        //        return NotFound();
        //    }

        //    var userVM = await _context.UserVM
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (userVM == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(userVM);
        //}

        //// POST: UserVMs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.UserVM == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.UserVM'  is null.");
        //    }
        //    var userVM = await _context.UserVM.FindAsync(id);
        //    if (userVM != null)
        //    {
        //        _context.UserVM.Remove(userVM);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool UserVMExists(int id)
        //{
        //    return _context.UserVM.Any(e => e.Id == id);
        //}
    }
}

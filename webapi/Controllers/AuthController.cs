using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        //private readonly AuthServices authServices;
        public static UserModel newUserModel = new UserModel();

        public AuthController(ApplicationDbContext context
            //AuthServices authServices
            )
        {
            _context = context;
            //this.authServices = authServices;
        }

        [HttpPost("register")]
        public ActionResult<UserModel> Register(UserRegister userRegister)
        {
            //var userExist = _context.Users.Any(user => userRegister.Email == user.Email);
            //if (userExist)
            //{
            //    return BadRequest("A user with this email address already exist");
            //}

            var hasher = new PasswordHasher<UserModel>();
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
            newUserModel.PasswordHash = hasher.HashPassword(null, userRegister.Password);
            newUserModel.FirstName = userRegister.FirstName;
            newUserModel.LastName = userRegister.LastName;
            newUserModel.Email = userRegister.Email;
            newUserModel.UserName = userRegister.UserName;
            newUserModel.DateJoined = DateTime.Now;
            newUserModel.DateOfBirth = (DateTime)userRegister.DateOfBirth;
            //return CreatedAtAction("Registration"; newUser);
            //return Ok(newUser);
            return Created("somewhere", newUserModel);

        }

        [HttpPost("login")]
        public ActionResult<UserModel> Register(string email, string password)
        {
            //var userExist = _context.Users.FirstAsync(user => email == user.Email);
            if (newUserModel.Email != email)
            {
                return BadRequest("Login Information does not match our records");
            }
            var hasher = new PasswordHasher<UserModel>();
            if (PasswordVerificationResult.Failed == hasher.VerifyHashedPassword(newUserModel, newUserModel.PasswordHash, password))
            {
                return BadRequest("Login Information does not match our records");

            }
            //return CreatedAtAction("Registration", newUser);
            //return Ok(newUser);
            return Ok(newUserModel);

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

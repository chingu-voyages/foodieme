using AutoMapper;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Services
{
    public class UsersServices : GenericServices<UserModel>, IUserService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public UsersServices(ApplicationDbContext _context, IMapper mapper) : base(_context)
        {
            context = _context;
            this.mapper = mapper;
        }

        public async Task<List<UserVM>> GetAllUsers()
        {
            var users = await context.Users
                .Include(user => user.CreatedMealRequests)
                .Include(user => user.CreatedRestaurants)
                .ToListAsync();
            var usersVM = mapper.Map<List<UserVM>>(users);
            return usersVM;
        }

        public async Task<UserVM> GetUser(string id)
        {
            var user = await context.Users
                .Include(user => user.CreatedMealRequests)
                .Include(user => user.CreatedRestaurants)
                .FirstOrDefaultAsync(user => user.Id == id);
            var userVM = mapper.Map<UserVM>(user);
            return userVM;
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userServices;

        public UsersController(IUserService userServices)
        {
            this.userServices = userServices;
        }
        // GET: api/<UsersController>
        [HttpGet, Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> GetAll()
        {
            var allUsers = await userServices.GetAllUsers();
            return Ok(allUsers);
        }

        // GET api/<UsersController>/dfjkdhskhjkdh
        [HttpGet("{id}"), Authorize]
        public async Task<IActionResult> Get(string id)
        {
            var user = await userServices.GetUser(id);
            return Ok(user);

        }
        
        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

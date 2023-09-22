using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using webapi.Interfaces;
using webapi.Models;

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
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> EditUserInfo([FromRoute] string id, [FromBody] UserVM model)
        {
            var currentUserId = User.FindFirst("sub")!.Value;
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Form");
            }
            //only allow own user to edit
            if (currentUserId != id)
            {
                return Unauthorized();
            }
            var user = await userServices.UpdateUser(id, model);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

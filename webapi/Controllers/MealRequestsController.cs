using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Interfaces;
using webapi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealRequestsController : ControllerBase
    {
        private readonly IMealRequestService mealRequestService;

        public MealRequestsController(ApplicationDbContext context, IMealRequestService mealRequestService)
        {
            this.mealRequestService = mealRequestService;
        }
        // GET: api/<MealRequestsController>
        [HttpGet, Authorize]
        public async Task<ActionResult<MealRequestVM>> GetAll()
        {
            //var mealRequestsList = mealRequestService.GetAllAsync();
            var mealRequests = await mealRequestService.GetAllMealRequests();
            return Ok(mealRequests);
            //return new string[] { "value1", "value2" };
        }

        // GET api/<MealRequestsController>/5
        [HttpGet("{id}"), Authorize]
        public string GetMealRequest(int id)
        {
            return "value";
        }

        // POST api/<MealRequestsController>
        [HttpPost, Authorize]
        public async Task<IActionResult> CreateMealRequest([FromBody] MealRequestCreateVM model)
        {
            Console.WriteLine($"model from create {model} ");
            if (!ModelState.IsValid)
            {
                return BadRequest("Form is incorrect");
            }


            var creatorId = User.FindFirst("sub")!.Value!;
            Console.WriteLine($"Got creatorId from Token {creatorId}");
            model.CreatorId = creatorId;
            try
            {
            var newMealRequest = await mealRequestService.CreateMealRequest(model);

            return CreatedAtAction(nameof (GetMealRequest),new {id= newMealRequest.Id} , newMealRequest);
            } catch (Exception ex) {
                return BadRequest(ex);
            }

        }

        // PUT api/<MealRequestsController>/5
        [HttpPut("{id}"), Authorize]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MealRequestsController>/5
        [HttpDelete("{id}"), Authorize]
        public void Delete(int id)
        {
        }
    }
}

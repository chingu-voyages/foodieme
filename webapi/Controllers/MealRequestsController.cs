using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using webapi.Constants;
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
            var mealRequests = await mealRequestService.GetAllMealRequests();
            return Ok(mealRequests);
        }        
        
        // TODO: Change thsi endpoint to /users/id/mealrequests to make it RESTful
        // GET: api/<MealRequestsController>/me
        [HttpGet("me"), Authorize]
        public async Task<ActionResult<MealRequestVM>> GetAllMyMealRequests()
        {
            var userId = User.FindFirst("sub")!.Value!;
            var mealRequests = await mealRequestService.GetAllMyMealRequests(userId);
            return Ok(mealRequests);
        }

        // GET api/<MealRequestsController>/5
        [HttpGet("{id:int}"), Authorize]
        public async Task<ActionResult<MealRequestVM>> GetMealRequest(int id)
        {
            var mealRequest = await mealRequestService.GetMealRequest(id);
            if (mealRequest == null)
            {
                return BadRequest();
            }
            return Ok(mealRequest);
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

                return CreatedAtAction(nameof(GetMealRequest), new { id = newMealRequest.Id }, newMealRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

       

        // PUT api/<MealRequestsController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> EditMealRequest([FromBody] MealRequestVM model, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            var currentUserId = User.FindFirst("sub")!.Value!;
            if (model.CreatorId != currentUserId)
            {
                // Make a full modification of the body
                return Unauthorized();
            }
            var mealrequestModel = await mealRequestService.UpdateMealRequest(model, id);
            return Ok(mealrequestModel);
          
        }

        // DELETE api/<MealRequestsController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var currentUserId = User.FindFirst("sub")!.Value!;
            //var result = await mealRequestService.DeleteMealRequest(id, currentUserId);
            var mealRequest = await mealRequestService.GetAsync(id);
            if (mealRequest == null)
            {
                return NotFound();
            }
            if (mealRequest.CreatorId != currentUserId || currentUserId != Admin.AdminUserId)
            {
                return Unauthorized();
            }
            await mealRequestService.DeleteMealRequest(id, currentUserId);
            return Ok("Deleted");
        }

        // PATCH api/<MealRequestsController>/5/join
        //[Route("/join")]
        [HttpPatch("{id}/join"), Authorize]
        public async Task<IActionResult> EditParticipation([FromRoute] int id)
        {
            var currentUserId = User.FindFirst("sub")!.Value!;

            try
            {
            await mealRequestService.EditParticipation(id, currentUserId);
            return Ok();

            } catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}

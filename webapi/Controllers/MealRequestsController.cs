using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
            var userId = User.FindFirst("sub")!.Value!;
            var mealRequests = await mealRequestService.GetAllMyMealRequests(userId);
            return Ok(mealRequests);
        }

        // GET api/<MealRequestsController>/5
        [HttpGet("{id}"), Authorize]
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
            //else
            var mealrequestModel = await mealRequestService.UpdateMealRequest(model, id);
            return Ok(mealrequestModel);
            //{
            //    // Not modifying entire entry, just adding companions
            //    // If currentUSer is in the companionsId list, delete it from the list
            //    if (model.CompanionsId.Contains(currentUserId))
            //    {
            //        await mealRequestService.LeaveMealRequest(id, currentUserId);

            //    }
            //    else
            //    {
            //        // add user to the companions list
            //        await mealRequestService.JoinMealRequest(id, currentUserId);

            //    }

            //Else, if' he's not, add him to the list
            //    return Ok(model);
            //}

            //IF not, check if current user is in the companions list
            // If he is, take him off. He is leaving the rquest
            // If he is not, add his to the compnaions lists
        }

        // DELETE api/<MealRequestsController>/5
        [HttpDelete("{id}"), Authorize]
        public void Delete(int id)
        {
        }

        // PATCH api/<MealRequestsController>/5/join
        //[Route("/join")]
        [HttpPatch("{id}/join"), Authorize]
        public async Task<IActionResult> EditParticipation([FromRoute] int id)
        {
            var currentUserId = User.FindFirst("sub")!.Value!;

            //if (model.CompanionsId.Contains(currentUserId))
            //{
            //    await mealRequestService.LeaveMealRequest(id, currentUserId);

            //}
            //else
            //{
            //    // add user to the companions list
            //    await mealRequestService.JoinMealRequest(id, currentUserId);

            //}
            try
            {
            await mealRequestService.EditParticipation(id, currentUserId);
            return Ok();

            } catch (Exception ex)
            {
                return BadRequest(ex);
            }

            //Else, if' he's not, add him to the list


            //IF not, check if current user is in the companions list
            // If he is, take him off. He is leaving the rquest
            // If he is not, add his to the compnaions lists
        }
    }
}

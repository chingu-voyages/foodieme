using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IRestaurantService restaurantServices;

        public RestaurantsController(ApplicationDbContext context, IRestaurantService restaurantServices)
        {
            _context = context;
            this.restaurantServices = restaurantServices;
        }

        // GET: api/RestaurantModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantVM>>> GetRestaurants()
        {
          if (_context.Restaurants == null)
          {
              return NotFound();
          }
          //Query
          //var restaurants = _context.Restaurants.Include(r => r.Creator).ToList();

            //var restaurants = await restaurantServices.GetAll();
            var restaurants = await restaurantServices.GetAllRestaurantsWithCreator();

            return restaurants;


            //return await _context.Restaurants.ToListAsync();
        }

        // GET: api/RestaurantModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantVM>> GetRestaurantVM(int id)
        {
          if (_context.Restaurants == null)
          {
              return NotFound();
          }
            var restaurantVM = await restaurantServices.GetRestaurant(id);

            if (restaurantVM == null)
            {
                return NotFound();
            }

            return restaurantVM;
        }

        // PUT: api/RestaurantModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurantModel(int id, RestaurantModel restaurantModel)
        {
            if (id != restaurantModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(restaurantModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RestaurantModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RestaurantModel>> PostRestaurantModel(RestaurantModel restaurantModel)
        {
          if (_context.Restaurants == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Restaurants'  is null.");
          }
            _context.Restaurants.Add(restaurantModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurantModel", new { id = restaurantModel.Id }, restaurantModel);
        }

        // DELETE: api/RestaurantModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurantModel(int id)
        {
            if (_context.Restaurants == null)
            {
                return NotFound();
            }
            var restaurantModel = await _context.Restaurants.FindAsync(id);
            if (restaurantModel == null)
            {
                return NotFound();
            }

            _context.Restaurants.Remove(restaurantModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RestaurantModelExists(int id)
        {
            return (_context.Restaurants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

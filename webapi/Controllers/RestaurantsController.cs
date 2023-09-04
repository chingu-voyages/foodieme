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

        // GET: api/Restaurants
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

        // GET: api/Restaurants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantVM>> GetRestaurant(int id)
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

        // PUT: api/Restaurants/5
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

        // POST: api/Restaurants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RestaurantModel>> CreateRestaurant([FromBody] RestaurantCreateVM model)
        {
            if (_context.Restaurants == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Restaurants'  is null.");
            }
            //_context.Restaurants.Add(restaurantModel);
            //await _context.SaveChangesAsync();
            var newRestaurant = await restaurantServices.CreateRestaurant(model);

            return CreatedAtAction(nameof(GetRestaurant), new { id = newRestaurant.Id }, newRestaurant);
        }

        // DELETE: api/Restaurants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurantModel(int id)
        {
            if (_context.Restaurants == null)
            {
                return NotFound();
            }
            //var restaurantModel = await _context.Restaurants.FindAsync(id);
            //if (restaurantModel == null)
            //{
            //    return NotFound();
            //}

            //_context.Restaurants.Remove(restaurantModel);
            //await _context.SaveChangesAsync();
            var isDelete = await restaurantServices.DeleteRestaurant(id);
            if (!isDelete) return NotFound();
            return NoContent();
        }

        private bool RestaurantModelExists(int id)
        {
            return (_context.Restaurants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

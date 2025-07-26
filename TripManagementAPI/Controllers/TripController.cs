using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripManagementAPI.Data;
using TripManagementAPI.Models;
namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TripController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/trip
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trips = await _context.Trips.ToListAsync();
            return Ok(trips);
        }

        // GET: api/trip/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var trip = await _context.Trips.FindAsync(id);
            if (trip == null)
                return NotFound();

            return Ok(trip);
        }

        // POST: api/trip
        [HttpPost]
        public async Task<IActionResult> Create(Trip trip)
        {
            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = trip.Id }, trip);
        }

        // PUT: api/trip/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Trip trip)
        {
            if (id != trip.Id)
                return BadRequest();

            var existingTrip = await _context.Trips.FindAsync(id);
            if (existingTrip == null)
                return NotFound();

            existingTrip.Name = trip.Name;
            existingTrip.Description = trip.Description;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/trip/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var trip = await _context.Trips.FindAsync(id);
            if (trip == null)
                return NotFound();

            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

using BookLibrary.Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RentalsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Rental>> CreateRental(Rental rental)
        {
            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(rental), new { id = rental.Id }, rental);
        }

        [HttpPost("rent")]
        public async Task<ActionResult<Rental>> RentBook(Guid userId, Guid bookId)
        {
            var rental = new Rental
            {
                UserId = userId,
                BookId = bookId,
                RentalDate = DateTime.UtcNow
            };

            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRental), new { userId = rental.UserId, bookId = rental.BookId }, rental);
        }

        [HttpGet("{userId}/{bookId}")]
        public async Task<ActionResult<Rental>> GetRental(Guid userId, Guid bookId)
        {
            var rental = await _context.Rentals
                .Include(r => r.User)
                .Include(r => r.Book)
                .FirstOrDefaultAsync(r => r.UserId == userId && r.BookId == bookId);

            if (rental == null)
            {
                return NotFound();
            }

            return rental;
        }

        [HttpPut("return")]
        public async Task<IActionResult> ReturnBook(Guid userId, Guid bookId)
        {
            var rental = await _context.Rentals
                .FirstOrDefaultAsync(r => r.UserId == userId && r.BookId == bookId && r.ReturnDate == null);

            if (rental == null)
            {
                return NotFound();
            }

            rental.ReturnDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<Rental>>> GetActiveRentals()
        {
            var activeRentals = await _context.Rentals
                .Include(r => r.User)
                .Include(r => r.Book)
                .Where(r => r.ReturnDate == null)
                .ToListAsync();

            return activeRentals;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rental>>> GetRentals()
        {
            return await _context.Rentals
                .Include(r => r.User)
                .Include(r => r.Book)
                .ToListAsync();
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<Rental>>> GetRentalsByUser(Guid id)
        {
            return await _context.Rentals
                .Where(r => r.UserId.Equals(id))
                .Include(r => r.User)
                .Include(r => r.Book)
                .ToListAsync();
        }
    }
}

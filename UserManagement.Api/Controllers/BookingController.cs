using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Data.Models;

namespace UserManagement.Api.Controllers
{
    [Route("api/Booking")]
    [ApiController]
    //[Authorize(Roles ="Admin")]
    public class BookingController : Controller
    {
        readonly ApplicationDbContext _applicationDbContext;
        public BookingController(ApplicationDbContext applicationDbContext) { 
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = _applicationDbContext.Bookings.ToList();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Booking booking)
        {
            _applicationDbContext.Bookings.Add(booking);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(booking);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Booking booking)
        {
            _applicationDbContext.Bookings.Update(booking);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(booking);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var booking = _applicationDbContext.Bookings.FirstOrDefault(x => x.BookingID == id);
            _applicationDbContext.Bookings.Remove(booking);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(booking);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var booking = await _applicationDbContext.Bookings.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }
        [HttpPost]
        [Route("Onayla/{id}")]
        public async Task<IActionResult> Onayla(int id)
        {
            var booking = await _applicationDbContext.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            booking.Status = "Onaylandı"; // Durumu güncelle
            await _applicationDbContext.SaveChangesAsync();
            return Ok(booking);
        }
        [HttpPost]
        [Route("Iptal/{id}")]
        public async Task<IActionResult> Iptal(int id)
        {
            var booking = await _applicationDbContext.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            booking.Status = "İptal Edildi"; // Durumu güncelle
            await _applicationDbContext.SaveChangesAsync();
            return Ok(booking);
        }
    }
}

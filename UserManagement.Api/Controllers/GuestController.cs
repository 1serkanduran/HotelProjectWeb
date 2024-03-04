using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Data.Models;

namespace UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        readonly ApplicationDbContext _applicationDbContext;
        public GuestsController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = _applicationDbContext.Guests.ToList();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Guest guest)
        {
            _applicationDbContext.Guests.Add(guest);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(guest);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Guest guest)
        {
            _applicationDbContext.Guests.Update(guest);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(guest);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var guest = _applicationDbContext.Guests.FirstOrDefault(x => x.GuestID == id);
            _applicationDbContext.Guests.Remove(guest);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(guest);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var guest = await _applicationDbContext.Guests.FindAsync(id);

            if (guest == null)
            {
                return NotFound();
            }

            return Ok(guest);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Data.Models;

namespace UserManagement.Api.Controllers
{
    [Route("api/Room")]
    [ApiController]
    //[Authorize(Roles ="Admin")]
    public class RoomController : Controller
    {
        readonly ApplicationDbContext _applicationDbContext;
        public RoomController(ApplicationDbContext applicationDbContext) { 
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = _applicationDbContext.Rooms.ToList();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Room room)
        {
            _applicationDbContext.Rooms.Add(room);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(room);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Room room)
        {
            _applicationDbContext.Rooms.Update(room);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(room);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var room = _applicationDbContext.Rooms.FirstOrDefault(x => x.RoomID == id);
            _applicationDbContext.Rooms.Remove(room);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(room);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var room = await _applicationDbContext.Rooms.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }
    }
}

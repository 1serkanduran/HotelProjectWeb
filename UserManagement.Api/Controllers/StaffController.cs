using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Data.Models;

namespace UserManagement.Api.Controllers
{
    [Route("api/Staff")]
    [ApiController]
    public class StaffController : Controller
    {
        readonly ApplicationDbContext _applicationDbContext;
        public StaffController(ApplicationDbContext applicationDbContext) { 
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = _applicationDbContext.Staff.ToList();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Staff staff)
        {
            _applicationDbContext.Staff.Add(staff);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(staff);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Staff staff)
        {
            _applicationDbContext.Staff.Update(staff);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(staff);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var staff = _applicationDbContext.Staff.FirstOrDefault(x => x.StaffID == id);
            _applicationDbContext.Staff.Remove(staff);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(staff);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var staff = await _applicationDbContext.Staff.FindAsync(id);

            if (staff == null)
            {
                return NotFound();
            }

            return Ok(staff);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Data.Models;

namespace UserManagement.Api.Controllers
{
    [Route("api/About")]
    [ApiController]
    //[Authorize(Roles ="Admin")]
    public class AboutController : Controller
    {
        readonly ApplicationDbContext _applicationDbContext;
        public AboutController(ApplicationDbContext applicationDbContext) { 
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = _applicationDbContext.Abouts.ToList();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] About about)
        {
            _applicationDbContext.Abouts.Add(about);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(about);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] About about)
        {
            _applicationDbContext.Abouts.Update(about);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(about);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var about = _applicationDbContext.Abouts.FirstOrDefault(x => x.AboutID == id);
            _applicationDbContext.Abouts.Remove(about);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(about);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var about = await _applicationDbContext.Abouts.FindAsync(id);

            if (about == null)
            {
                return NotFound();
            }

            return Ok(about);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Data.Models;

namespace UserManagement.Api.Controllers
{
    [Route("api/Service")]
    [ApiController]
    //[Authorize(Roles ="Admin")]
    public class ServiceController : Controller
    {
        readonly ApplicationDbContext _applicationDbContext;
        public ServiceController(ApplicationDbContext applicationDbContext) { 
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = _applicationDbContext.Services.ToList();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Service service)
        {
            _applicationDbContext.Services.Add(service);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(service);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Service service)
        {
            _applicationDbContext.Services.Update(service);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(service);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var service = _applicationDbContext.Services.FirstOrDefault(x => x.ServiceID == id);
            _applicationDbContext.Services.Remove(service);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(service);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var service = await _applicationDbContext.Services.FindAsync(id);

            if (service == null)
            {
                return NotFound();
            }

            return Ok(service);
        }
    }
}

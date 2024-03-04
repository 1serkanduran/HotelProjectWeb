using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Data.Models;

namespace UserManagement.Api.Controllers
{
    [Route("api/Subscribe")]
    [ApiController]
    //[Authorize(Roles ="Admin")]
    public class SubscribeController : Controller
    {
        readonly ApplicationDbContext _applicationDbContext;
        public SubscribeController(ApplicationDbContext applicationDbContext) { 
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = _applicationDbContext.Subscribes.ToList();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Subscribe subscribe)
        {
            _applicationDbContext.Subscribes.Add(subscribe);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(subscribe);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Subscribe subscribe)
        {
            _applicationDbContext.Subscribes.Update(subscribe);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(subscribe);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var subscribe = _applicationDbContext.Subscribes.FirstOrDefault(x => x.SubscribeID == id);
            _applicationDbContext.Subscribes.Remove(subscribe);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(subscribe);
        }
    }
}

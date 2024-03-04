using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Data.Models;

namespace UserManagement.Api.Controllers
{
    [Route("api/Testimonial")]
    [ApiController]
    //[Authorize(Roles ="Admin")]
    public class TestimonialController : Controller
    {
        readonly ApplicationDbContext _applicationDbContext;
        public TestimonialController(ApplicationDbContext applicationDbContext) { 
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = _applicationDbContext.Testimonials.ToList();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Testimonial testimonial)
        {
            _applicationDbContext.Testimonials.Add(testimonial);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(testimonial);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Testimonial testimonial)
        {
            _applicationDbContext.Testimonials.Update(testimonial);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(testimonial);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var testimonial = _applicationDbContext.Testimonials.FirstOrDefault(x => x.TestimonialID == id);
            _applicationDbContext.Testimonials.Remove(testimonial);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(testimonial);
        }
    }
}

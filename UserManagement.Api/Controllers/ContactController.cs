using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Data.Models;

namespace UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        readonly ApplicationDbContext _applicationDbContext;
        public ContactController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = _applicationDbContext.Contacts.ToList();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Contact contact)
        {
            _applicationDbContext.Contacts.Add(contact);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(contact);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Contact contact)
        {
            _applicationDbContext.Contacts.Update(contact);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(contact);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var contact = _applicationDbContext.Contacts.FirstOrDefault(x => x.ContactID == id);
            _applicationDbContext.Contacts.Remove(contact);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(contact);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _applicationDbContext.Contacts.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }
    }
}

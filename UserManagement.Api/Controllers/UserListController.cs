using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Data.Models;

namespace BookStore.Api.Controllers
{
    [Route("api/userlist")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class UserListController : ControllerBase
    {
        readonly ApplicationDbContext _applicationDbContext;
        public UserListController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

    }
}

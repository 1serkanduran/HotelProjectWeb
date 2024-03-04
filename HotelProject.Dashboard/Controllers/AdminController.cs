using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Dashboard.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult _AdminLayout()
        {
            return View();
        }
    }
}

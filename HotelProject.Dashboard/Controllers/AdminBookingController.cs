using HotelProject.Dashboard.Models.Booking;
using HotelProject.Dashboard.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.Dashboard.Controllers
{
    public class AdminBookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminBookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Home()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:5001/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<BookingViewModel>>(jsondata);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Onayla(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsync($"https://localhost:5001/api/Booking/Onayla/{id}", null);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı bir şekilde onaylandı
                return RedirectToAction("Home"); // veya istediğiniz başka bir sayfaya yönlendirme yapabilirsiniz
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                // Belirtilen id'ye sahip rezervasyon bulunamadı
                return NotFound();
            }
            else
            {
                // API'den beklenmeyen bir hata döndü
                return StatusCode((int)response.StatusCode);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Iptal(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsync($"https://localhost:5001/api/Booking/Iptal/{id}", null);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı bir şekilde onaylandı
                return RedirectToAction("Home"); // veya istediğiniz başka bir sayfaya yönlendirme yapabilirsiniz
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                // Belirtilen id'ye sahip rezervasyon bulunamadı
                return NotFound();
            }
            else
            {
                // API'den beklenmeyen bir hata döndü
                return StatusCode((int)response.StatusCode);
            }
        }
    }
}

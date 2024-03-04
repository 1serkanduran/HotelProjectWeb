using System.ComponentModel.DataAnnotations;

namespace HotelProject.Dashboard.Models.Service
{
    public class ServiceViewModel
    {
        public int ServiceID { get; set; }
        public string? ServiceIcon { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

    }
}

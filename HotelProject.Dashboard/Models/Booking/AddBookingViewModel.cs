namespace HotelProject.Dashboard.Models.Booking
{
    public class AddBookingViewModel
    {
        public string? Name { get; set; }
        public string? Mail { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public string? AdultCount { get; set; }
        public string? ChildCount { get; set; }
        public string? RoomCount { get; set; }
        public string? SpecialRequest { get; set; }
        public string? Status { get; set; }
    }
}

namespace HotelProject.Dashboard.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => RequestId != null; // veya string.IsNullOrEmpty(RequestId) �eklinde de kontrol edebilirsiniz
    }
}
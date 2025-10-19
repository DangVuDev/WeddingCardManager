namespace WeddingServer.Dto.Request
{
    public class GuestRequest
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Url { get; set; } = "";
        public bool Sent { get; set; } // Đã gửi thiệp
        public string? Status { get; set; } // "accepted" | "declined" | null
    }
}

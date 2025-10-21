using Core.Model.Base;

namespace WeddingServer.Dto.Model
{
    public class GuestModel : BaseModel
    {
        public string GuestId { get; set; } = ""; 
        public string Name { get; set; } = "";
        public string Url { get; set; } = "";
        public bool Sent { get; set; } // Đã gửi thiệp
        public string? Status { get; set; } // "accepted" | "declined" | null
    }
}

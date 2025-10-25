    using Core.Model.Base;

    namespace WeddingServer.Dto.Model
    {
        public class WeddingConfigModel : BaseModel
        {
            public string GroomName { get; set; } = "";
            public string BrideName { get; set; } = "";
            public string GuestName { get; set; } = "";
            public DateTime WeddingDate { get; set; }
            public string WeddingDateDisplay { get; set; } = "";
            public string WeddingTime { get; set; } = "";
            public string Venue { get; set; } = "";
            public string Address { get; set; } = "";
            public string MapUrl { get; set; } = "";
            public string? MapViewUrl { get; set; } = "";
            public string HeroImage { get; set; } = "";
            public string MusicUrl { get; set; } = "";

            public List<TimelineEvent> Timeline { get; set; } = new();
            public List<string> DressCode { get; set; } = new();
            public List<LoveStory> Stories { get; set; } = new();
            public List<string> Gallery { get; set; } = new();
            public List<ContactInfo> Contacts { get; set; } = new();
        }

        public class TimelineEvent
        {
            public string Time { get; set; } = "";
            public string Icon { get; set; } = "";
            public string Title { get; set; } = "";
            public string Desc { get; set; } = "";
        }

        public class LoveStory
        {
            public string Icon { get; set; } = "";
            public string Title { get; set; } = "";
            public string Desc { get; set; } = "";
            public string Image { get; set; } = "";
        }

        public class ContactInfo
        {
            public string Icon { get; set; } = "";
            public string Name { get; set; } = "";
            public string Phone { get; set; } = "";
            public string Email { get; set; } = "";
            public string? QrCodeImageUrl { get; set; } = "";
        }
    }

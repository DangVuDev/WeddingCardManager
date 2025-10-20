using WeddingServer.Dto.Model;

namespace WeddingServer.Static
{
    public static class DataStatic
    {
        public static string PassHash { get; set; } = "";
        public static string IP_ALLOW = "";

        public static WeddingConfigModel TempReview { get; set; } = new WeddingConfigModel();
    }
}

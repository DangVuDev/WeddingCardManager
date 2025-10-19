using Core.Model.Base;

namespace WeddingServer.Dto.Model
{
    public class WishModel : BaseModel
    {
        public string Name { get; set; } = "";
        public string Message { get; set; } = "";
    }
}

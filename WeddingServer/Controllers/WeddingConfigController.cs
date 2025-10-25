using Core.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Text.Json;
using System.Threading.Tasks;
using WeddingServer.Dto.Model;
using WeddingServer.Dto.Request;

namespace WeddingServer.Controllers
{
    [ApiController]
    [Route("api/wedding/admin")]
    public class WeddingConfigController(IBaseService<WeddingConfigModel> baseService) : ControllerBase
    {
        private readonly IBaseService<WeddingConfigModel> _baseService = baseService;



        [HttpGet("config")]
        public async Task<IActionResult> GetConfig()
        {
            var getConfigData = await _baseService.GetAllAsync();
            if(getConfigData.IsSuccess)
            {
                return Ok(getConfigData.Data!.FirstOrDefault());
            }
            return BadRequest("Unable to find data config");
        }

        [HttpPost("config")]
        public async Task<IActionResult> SaveConfig([FromBody] WeddingConfigRequest request)
        {
            if (request == null)
                return BadRequest("Request cannot be null.");

            // Convert Request → Model
            var model = new WeddingConfigModel
            {
                GroomName = request.GroomName,
                BrideName = request.BrideName,
                GuestName = request.GuestName,
                WeddingDate = request.WeddingDate,
                WeddingDateDisplay = request.WeddingDateDisplay,
                WeddingTime = request.WeddingTime,
                Venue = request.Venue,
                Address = request.Address,
                MapUrl = request.MapUrl,
                MapViewUrl = request.MapViewUrl,
                HeroImage = request.HeroImage,
                MusicUrl = request.MusicUrl,
                Timeline = request.Timeline?.Select(t => new TimelineEvent
                {
                    Time = t.Time,
                    Icon = t.Icon,
                    Title = t.Title,
                    Desc = t.Desc
                }).ToList() ?? new List<TimelineEvent>(),
                DressCode = request.DressCode ?? new List<string>(),
                Stories = request.Stories?.Select(s => new LoveStory
                {
                    Icon = s.Icon,
                    Title = s.Title,
                    Desc = s.Desc,
                    Image = s.Image
                }).ToList() ?? new List<LoveStory>(),
                Gallery = request.Gallery ?? new List<string>(),
                Contacts = request.Contacts?.Select(c => new ContactInfo
                {
                    Icon = c.Icon,
                    Name = c.Name,
                    Phone = c.Phone,
                    Email = c.Email,
                    QrCodeImageUrl = c.QrCodeImageUrl
                }).ToList() ?? new List<ContactInfo>(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            // Lấy config cũ
            var getConfigData = await _baseService.GetAllAsync();
            if (getConfigData.IsSuccess && getConfigData.Data != null && getConfigData.Data.Any())
            {
                var oldConfig = getConfigData.Data.FirstOrDefault();
                if (oldConfig != null && !string.IsNullOrEmpty(oldConfig.Id))
                {
                    await _baseService.DeleteAsync(oldConfig.Id);
                }
            }

            // Lưu config mới
            var saveResult = await _baseService.CreateAsync(model);

            if (!saveResult.IsSuccess)
            {
                return BadRequest("Unable to save wedding config data.");
            }

            return Ok(new
            {
                message = "Wedding config saved successfully!",
                data = saveResult.Data
            });
        }

        


    }
}

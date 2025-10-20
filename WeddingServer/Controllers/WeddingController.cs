using Core.Extention;
using Core.Service.DeployService;
using Core.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using System.Text;
using WeddingServer.Dto.Model;
using WeddingServer.Dto.Request;
using WeddingServer.Static;
using WeddingServer.UI;

namespace WeddingServer.Controllers
{
    [ApiController]
    [Route("api/wedding")]
    public class WeddingController(IBaseService<WishModel> wishService, IBaseService<GuestModel> guestService, IBaseService<WeddingConfigModel> baseService) : Controller
    {

        private readonly IBaseService<WishModel> _wishService = wishService;
        private readonly IBaseService<GuestModel> _guestService = guestService;
        private readonly IBaseService<WeddingConfigModel> _baseService = baseService;

        [HttpGet("get-ip")]
        public IActionResult Get()
        {
            string clientIp = Request.GetClientIp();
            return Ok(clientIp);

        }

        [HttpGet]
        public IActionResult Start() => View("~/Views/Index.cshtml");

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest();
            }
            string clientIp = Request.GetClientIp();
            if (string.IsNullOrEmpty(clientIp)) return BadRequest("Request anonymos");

            if (DataStatic.PassHash == request.Password.ToSha256())
            {

                DataStatic.IP_ALLOW = clientIp.ToSha256();
                return Ok();
            }
            return BadRequest("PassWord not correct");

        }

        [HttpGet("admin/guests")]
        public async Task<IActionResult> ManageGuests()
        {
            string clientIp = Request.GetClientIp();
            if (clientIp.ToSha256() == DataStatic.IP_ALLOW)
            {
                var guestsResult = await _guestService.GetAllAsync(0, 1000);
                return View("~/Views/ManageGuests.cshtml", guestsResult.Data);
            }
            return View("~/Views/Index.cshtml");

        }

        [HttpPost("add-guest")]
        public async Task<IActionResult> AddGuest([FromBody] GuestRequest newGuest)
        {
            if (string.IsNullOrWhiteSpace(newGuest.Name) || string.IsNullOrWhiteSpace(newGuest.Id))
                return BadRequest("Thiếu thông tin khách mời.");

            string clientIp = Request.GetClientIp();
            if (clientIp.ToSha256() == DataStatic.IP_ALLOW)
            {
                var guest = await _guestService.GetOneByFilterAsync(g => g.GuestId == newGuest.Id);

                // Kiểm tra trùng ID
                if (guest.IsSuccess)
                    return Conflict("ID đã tồn tại.");
                GuestModel newGuestModel = new()
                {
                    GuestId = newGuest.Id,
                    Name = newGuest.Name,
                    Url = newGuest.Url,
                    Sent = false,
                    Status = null
                };
                await _guestService.CreateAsync(newGuestModel);
                return Ok(newGuest);
            }

            return View("~/Views/Index.cshtml");
        }

        [HttpPost("mark-sent")]
        public async Task<IActionResult> MarkInvitationSent([FromBody] MarkRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.GuestId))
                return BadRequest("Thiếu thông tin khách mời.");
            string clientIp = Request.GetClientIp();
            if (clientIp.ToSha256() == DataStatic.IP_ALLOW)
            {
                var guestResult = await _guestService.GetOneByFilterAsync(g => g.GuestId == request.GuestId);
                if (!guestResult.IsSuccess || guestResult.Data == null)
                    return NotFound("Guest not found.");
                var guest = guestResult.Data;
                guest.Sent = true;
                var updateResult = await _guestService.UpdateAsync(guest.Id, guest);
                if (!updateResult.IsSuccess)
                    return StatusCode(500, "Failed to mark invitation as sent.");
                return Ok(new { success = true, message = "Invitation marked as sent." });
            }
            return View("~/Views/Index.cshtml");
        }
        [HttpPost("rsvp")]
        [AllowAnonymous]
        public async Task<IActionResult> SubmitRsvp([FromBody] RsvpRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.GuestId))
                request.GuestId = "default";

            var guestResult = await _guestService.GetOneByFilterAsync(g => g.GuestId == request.GuestId);
            if (!guestResult.IsSuccess || guestResult.Data == null)
                return NotFound("Guest not found.");

            var guest = guestResult.Data;
            guest.Status = request.IsAttending ? "accepted" : "declined";
            guest.UpdatedAt = DateTime.UtcNow;

            var updateResult = await _guestService.UpdateAsync(guest.Id, guest);
            if (!updateResult.IsSuccess)
                return StatusCode(500, "Failed to update RSVP status.");

            return Ok(new { success = true, message = "RSVP submitted successfully." });
        }


        [HttpGet("ui-wedding-card")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUIWeddingCard([FromQuery] string id)
        {
            var getConfigData = await _baseService.GetAllAsync();
            var data = getConfigData.Data!.FirstOrDefault();
            if (!getConfigData.IsSuccess || data == null)
            {
                return BadRequest("Cant not get config data");
            }


            var guest = await _guestService.GetOneByFilterAsync(g => g.GuestId == id);
            string visited = guest!.IsSuccess && guest?.Data != null ? guest.Data.Name : "Quý khách";

            data.GuestName = visited;
            return View("Views/WeddingCard.cshtml", data);


            //string template = UITemplate.GetWeddingCard(visited);

            // return Content(template.ToString(), "text/html", Encoding.UTF8);
        }

        [HttpPost("wish")]
        public async Task<IActionResult> PostWish([FromBody] WishRequest model)
        {
            if (string.IsNullOrWhiteSpace(model.Name) || string.IsNullOrWhiteSpace(model.Message))
                return BadRequest("Invalid data");

            // TODO: Lưu vào MongoDB, SQL hoặc file JSON
            Console.WriteLine($"{model.Name} gửi lời chúc: {model.Message}");


            var modelWish = new WishModel
            {
                Name = model.Name,
                Message = model.Message
            };

            await _wishService.CreateAsync(modelWish);

            return Ok(new { success = true });
        }

        [HttpGet("admin/wishes/view")]
        public async Task<IActionResult> AdminWishes()
        {
            string clientIp = Request.GetClientIp();
            if (clientIp.ToSha256() == DataStatic.IP_ALLOW)
            {
                var wishesResult = await _wishService.GetAllAsync(0, 1000);
                return View("~/Views/Wish.cshtml", wishesResult.Data);
            }
            return View("~/Views/Index.cshtml");
        }

        [HttpGet("admin/config/view")]
        public IActionResult AdminConfig()
        {
            string clientIp = Request.GetClientIp();
            if (clientIp.ToSha256() == DataStatic.IP_ALLOW)
            {
                return View("~/Views/WeddingConfig.cshtml");
            }
            return View("~/Views/Index.cshtml");
        }

        [HttpPost("save-review")]
        public IActionResult Review(WeddingConfigRequest request)
        {
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
                    Email = c.Email
                }).ToList() ?? new List<ContactInfo>(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            DataStatic.TempReview = model;
            return Ok("Luu thanh cong");
        }
        [HttpGet("review")]
        public IActionResult Review()
        {
            if(DataStatic.TempReview == null)
            {
                return BadRequest("No review data available");
            }
            return View("Views/WeddingCard.cshtml", DataStatic.TempReview);
        }

        [HttpGet("manager")]
        public IActionResult Manager()
        {
            string clientIp = Request.GetClientIp();
            if (clientIp.ToSha256() == DataStatic.IP_ALLOW)
            {
                return View("~/Views/Menu.cshtml");
            }
            return View("~/Views/Index.cshtml");
        }

        public class RsvpRequest
        {
            public string GuestId { get; set; } = string.Empty;
            public bool IsAttending { get; set; }
        }
        public class LoginRequest
        {
            public string Password { get; set; } = string.Empty;
        }
        public class MarkRequest
        {
            public string GuestId { get; set; } = string.Empty;

        }
    }
}

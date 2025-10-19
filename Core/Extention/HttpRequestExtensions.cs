using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Core.Extention
{
    public class RequesterInfo
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public bool IsExpired { get; set; } = true;
        public DateTime? Expiration { get; set; }
    }

    public static class HttpRequestExtensions
    {
        /// <summary>
        /// Lấy thông tin requester từ JWT token trong header hoặc query string (SignalR)
        /// </summary>

        public static string GetClientIp(this HttpRequest request)
        {
            // Lấy IP từ HttpContext.Connection.RemoteIpAddress
            string? ipAddress = request.HttpContext.Connection.RemoteIpAddress?.ToString();

            // Kiểm tra nếu server đứng sau proxy/load balancer
            if (request.Headers.ContainsKey("X-Forwarded-For"))
            {
                // Lấy IP đầu tiên trong header X-Forwarded-For (IP gốc của client)
                ipAddress = request.Headers["X-Forwarded-For"].FirstOrDefault()?.Split(',').FirstOrDefault()?.Trim();
            }

            // Trả về IP, kể cả IPv6 loopback (::1), không chuyển đổi
            return string.IsNullOrEmpty(ipAddress) ? "Unknown" : ipAddress;
        }
        public static RequesterInfo? GetInfoRequester(this HttpRequest request)
        {
            string? token = null;

            // 1. Lấy token từ header Authorization
            if (request.Headers.TryGetValue("Authorization", out var authHeader))
            {
                var header = authHeader.FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(header) && header.StartsWith("Bearer "))
                {
                    token = header.Substring("Bearer ".Length).Trim();
                }
            }

            // 2. Nếu không có header, thử query string (SignalR)
            if (string.IsNullOrEmpty(token))
            {
                token = request.Query["access_token"].FirstOrDefault();
            }

            if (string.IsNullOrEmpty(token))
            {
                return new RequesterInfo(); // token không có => thông tin rỗng
            }

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                var expClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Exp)?.Value;
                DateTime? exp = null;
                bool isExpired = true;

                if (long.TryParse(expClaim, out var expSeconds))
                {
                    exp = DateTimeOffset.FromUnixTimeSeconds(expSeconds).UtcDateTime;
                    isExpired = exp < DateTime.UtcNow;
                }

                var requester = new RequesterInfo
                {
                    UserName = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value,
                    Email = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email)?.Value,
                    Expiration = exp,
                    IsExpired = isExpired
                };

                if(string.IsNullOrEmpty(requester.UserName) || string.IsNullOrEmpty(requester.Email) || isExpired)
                    return null;

                return requester;
            }
            catch
            {
                return null; // token không hợp lệ
            }
        }
    }
}

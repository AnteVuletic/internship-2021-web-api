using Microsoft.AspNetCore.Http;

namespace WebApiLecture.Domain.Services
{
    public class UserProviderService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly JwtService _jwtService;

        public UserProviderService(IHttpContextAccessor httpContextAccessor, JwtService jwtService)
        {
            _httpContextAccessor = httpContextAccessor;
            _jwtService = jwtService;
        }

        public int GetUserId()
        {
            var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            return _jwtService.GetUserIdFromToken(token);
        }
    }
}

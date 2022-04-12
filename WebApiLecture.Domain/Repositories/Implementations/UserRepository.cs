using Microsoft.EntityFrameworkCore;
using WebApiLecture.Data.Models;
using WebApiLecture.Domain.Helpers;
using WebApiLecture.Domain.Models;
using WebApiLecture.Domain.Repositories.Interfaces;
using WebApiLecture.Domain.Services;

namespace WebApiLecture.Domain.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly WebApiLectureContext _webApiLectureContext;
        private readonly JwtService _jwtService;

        public UserRepository(WebApiLectureContext webApiLectureContext, JwtService jwtService)
        {
            _webApiLectureContext = webApiLectureContext;
            _jwtService = jwtService;
        }

        public async Task<string?> Login(LoginModel model)
        {
            var user = await _webApiLectureContext
                .Users
                .FirstOrDefaultAsync(u => u.Email.ToLower() == model.Email.ToLower());

            if (user == null)
            {
                return null;
            }

            var isValid = HashHelper.ValidatePassword(model.Password, user.Password);

            if (!isValid)
            {
                return null;
            }

            var token = _jwtService.GetJwtToken(user.MapEntityToUserModel());

            return token;
        }

        public async Task<bool> Register(RegisterModel model)
        {
            if (model.Password != model.RepeatPassword)
            {
                return false;
            }

            var isTaken = await _webApiLectureContext
                .Users
                .AnyAsync(u => u.Email.ToLower() == model.Email.ToLower());

            if (isTaken)
            {
                return false;
            }

            var user = model.MapToUserEntity();
            await _webApiLectureContext.Users.AddAsync(user);
            await _webApiLectureContext.SaveChangesAsync();

            return true;
        }
    }
}

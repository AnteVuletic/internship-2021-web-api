using WebApiLecture.Domain.Models;

namespace WebApiLecture.Domain.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<string?> Login(LoginModel model);
        Task<bool> Register(RegisterModel model);
    }
}

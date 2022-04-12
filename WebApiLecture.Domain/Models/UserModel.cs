using System.ComponentModel.DataAnnotations;
using WebApiLecture.Data.Models.Entities;
using WebApiLecture.Domain.Helpers;

namespace WebApiLecture.Domain.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
    }

    public class RegisterModel
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? RepeatPassword { get; set; } 
    }

    public class LoginModel
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }

    public static class UserModelExtensions
    {
        public static User MapToUserEntity(this RegisterModel model)
        {
            return new User
            {
                Email = model.Email.ToLower(),
                Password = HashHelper.Hash(model.Password)
            };
        }

        public static UserModel MapEntityToUserModel(this User user)
        {
            return new UserModel
            {
                Id = user.Id,
                Email = user.Email,
            };
        }
    }
}

using Jose;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;
using WebApiLecture.Domain.Configurations;
using WebApiLecture.Domain.Models;

namespace WebApiLecture.Domain.Services
{
    public class JwtService
    {
        private readonly JwtConfiguration _jwtConfiguration;

        private double CurrentSeconds => Math.Round(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);

        public JwtService(IOptions<JwtConfiguration> configuration)
        {
            _jwtConfiguration = configuration.Value;
        }

        public string GetJwtToken(UserModel model)
        {
            var payload = new JwtModel
            {
                Issuer = _jwtConfiguration.Issuer,
                Audience = _jwtConfiguration.Audience,
                Expiry = CurrentSeconds + 300,
                Id = model.Id,
                Email = model.Email
            };

            var serializedPayload = JsonSerializer.Serialize(payload);

            return JWT.Encode(serializedPayload, Encoding.UTF8.GetBytes(_jwtConfiguration.AudienceSecret), JwsAlgorithm.HS256);
        }

        public int GetUserIdFromToken(string token)
        {
            var jwtModel = DecodeToken(token);

            return jwtModel?.Id ?? 0;
        }

        public JwtModel? DecodeToken(string token)
        {
            var decodedToken = JWT.Decode(token, Encoding.UTF8.GetBytes(_jwtConfiguration.Audience));
            var jwtModel = JsonSerializer.Deserialize<JwtModel>(decodedToken);

            return jwtModel;
        }

        public string? GetNewToken(string existingToken)
        {
            var jwtModel = DecodeToken(existingToken);

            if (jwtModel == null)
                return null;

            if (CurrentSeconds - jwtModel.Expiry > 86400)
                return null;

            var payload = new JwtModel
            {
                Issuer = _jwtConfiguration.Issuer,
                Audience = _jwtConfiguration.Audience,
                Expiry = CurrentSeconds + 300,
                Id = jwtModel.Id,
                Email = jwtModel.Email
            };

            var serializedPayload = JsonSerializer.Serialize(payload);

            return JWT.Encode(serializedPayload, Encoding.UTF8.GetBytes(_jwtConfiguration.AudienceSecret), JwsAlgorithm.HS256);
        }
    }
}

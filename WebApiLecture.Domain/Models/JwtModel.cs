using System.Text.Json.Serialization;

namespace WebApiLecture.Domain.Models
{
    public class JwtModel
    {
        [JsonPropertyName("iss")]
        public string Issuer { get; set; } = string.Empty;
        [JsonPropertyName("aud")]
        public string Audience { get; set; } = string.Empty;
        [JsonPropertyName("exp")]
        public double Expiry { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;
    }
}

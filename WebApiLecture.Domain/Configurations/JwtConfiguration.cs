namespace WebApiLecture.Domain.Configurations
{
    public class JwtConfiguration
    {
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string AudienceSecret { get; set; } = string.Empty;
    }
}

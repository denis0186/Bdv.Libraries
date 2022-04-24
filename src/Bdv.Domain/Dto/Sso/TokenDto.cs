namespace Bdv.Domain.Dto.Sso
{
    /// <summary>
    /// Token pair
    /// </summary>
    public class TokenDto
    {
        /// <summary>
        /// Access token string
        /// </summary>
        public string AccessToken { get; set; } = string.Empty;

        /// <summary>
        /// Refresh token string
        /// </summary>
        public string RefreshToken { get; set; } = string.Empty;
    }
}

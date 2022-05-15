using Bdv.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Encodings.Web;

namespace Bdv.Authentication.AuthenticationHandlers
{
    public class BdvAuthenticationHandler : AuthenticationHandler<BdvAuthenticationSchemeOptions>
    {
        private readonly JwtSecurityTokenHandler _jwtHandler = new();
        private readonly ITokenValidationSettings _tokenValidationSettings;
        private readonly IRsaKeyReader _rsaKeyReader;

        public BdvAuthenticationHandler(
            IOptionsMonitor<BdvAuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            ITokenValidationSettings tokenValidationSettings,
            IRsaKeyReader rsaKeyReader)
            : base(options, logger, encoder, clock)
        {
            _tokenValidationSettings = tokenValidationSettings;
            _rsaKeyReader = rsaKeyReader;
        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey(Options.TokenHeader))
            {
                return AuthenticateResult.Fail("Token header wasn't provided");
            }

            var token = Request.Headers[Options.TokenHeader].ToString();
            
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateLifetime = true,
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _tokenValidationSettings.Issuer,
                IssuerSigningKey = await _rsaKeyReader.GetPublicKeyAsync(_tokenValidationSettings.RsaPublicKey),
            };

            var claimsPrincipal = _jwtHandler.ValidateToken(token, tokenValidationParameters, out _);
            return AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name));
        }
    }
}

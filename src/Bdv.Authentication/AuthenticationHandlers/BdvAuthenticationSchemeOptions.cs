using Microsoft.AspNetCore.Authentication;

namespace Bdv.Authentication.AuthenticationHandlers
{
    public class BdvAuthenticationSchemeOptions : AuthenticationSchemeOptions
    {
        public string TokenHeader { get; set; } = "Token";
    }
}

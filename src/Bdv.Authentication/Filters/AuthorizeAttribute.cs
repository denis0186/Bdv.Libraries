using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bdv.Authentication.Attributes
{
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public AuthorizeAttribute(string permission)
        {
            Permission = permission;
        }

        /// <summary>
        /// Permission name
        /// </summary>
        public string Permission { get; init; }

        /// <summary>
        /// Role name
        /// </summary>
        public string? Role { get; init; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity?.IsAuthenticated != true)
            {
                context.Result = new UnauthorizedResult();
            }

            var permissions = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Permissions")?.Value.Split(',');
            if (permissions?.Contains(Permission) != true)
            {
                context.Result = new ContentResult { StatusCode = 403, Content = "" };
            }
        }
    }
}

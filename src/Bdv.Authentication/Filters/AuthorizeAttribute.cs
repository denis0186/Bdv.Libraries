using Bdv.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace Bdv.Authentication.Attributes
{
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private const string AUTHORIZATION_FAILED = "Authorization failed";

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
                context.Result = new ContentResult
                {
                    ContentType = "text/json",
                    StatusCode = 401,
                    Content = JsonSerializer.Serialize(new WebApiErrorDto
                    {
                        Message = AUTHORIZATION_FAILED,
                        Error = "Not authenticated"
                    }),
                };

                return;
            }

            var permissions = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Permissions")?.Value.Split(',');
            if (permissions?.Contains(Permission) != true)
            {
                context.Result = new ContentResult
                {
                    ContentType = "text/json",
                    StatusCode = 403,
                    Content = JsonSerializer.Serialize(new WebApiErrorDto
                    {
                        Message = AUTHORIZATION_FAILED,
                        Error = "No permission"
                    }),
                };
            }
        }
    }
}

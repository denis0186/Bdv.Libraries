namespace Bdv.Authentication.Attributes
{
    public class AuthorizeAttribute : Attribute
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
    }
}

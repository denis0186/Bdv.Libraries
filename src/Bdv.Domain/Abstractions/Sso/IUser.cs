namespace Bdv.Domain.Abstractions.Sso
{
    public interface IUser : IEntity<Guid>
    {
        /// <summary>
        /// User e-mail
        /// </summary>
        string? Email { get; set; }

        /// <summary>
        /// User phone number
        /// </summary>
        string? Phone { get; set; }

        /// <summary>
        /// User login
        /// </summary>
        string? Login { get; set; }
    }
}

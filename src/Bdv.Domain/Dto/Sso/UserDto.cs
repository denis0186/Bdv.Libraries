using Bdv.Domain.Abstractions.Sso;

namespace Bdv.Domain.Dto.Sso
{
    public record UserDto : DtoBase<int>, IUser
    {
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Login { get; set; }
    }
}

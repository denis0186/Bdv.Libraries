namespace Bdv.Domain.Dto
{
    public record WebApiErrorDto
    {
        public string? Message { get; set; }
        
        public string? Error { get; set; }
    }
}

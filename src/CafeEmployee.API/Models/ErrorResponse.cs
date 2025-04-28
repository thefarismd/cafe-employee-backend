namespace CafeEmployee.API.Models
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public string Path { get; set; } = string.Empty;

        public ErrorResponse(int statusCode, string message, List<string>? errors = null, string? path = null)
        {
            StatusCode = statusCode;
            Message = message;
            Errors = errors ?? new List<string>();
            Path = path ?? string.Empty;
        }
    }
}
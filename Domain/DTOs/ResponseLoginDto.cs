namespace Domain.DTOs
{
    public class ResponseLoginDto
    {
        public string Token { get; set; }
        public ResponseUserLoginDto Usuario { get; set; }
    }
}
namespace Domain.DTOs
{
    public class ResponseUserLoginDto
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public int RolId { get; set; }
    }
}
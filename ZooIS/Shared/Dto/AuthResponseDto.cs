namespace ZooIS.Shared.Dto
{
    public class AuthResponseDto
    {
        public string Username { get; set; } = string.Empty;
        public string IdToken { get; set; } = string.Empty;
        public DateTime ExpiresIn { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public int UserId { get; set; }
        public bool PassResetRequest { get; set; }
    }
}

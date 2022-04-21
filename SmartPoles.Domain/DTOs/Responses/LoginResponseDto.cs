namespace SmartPoles.Domain.DTOs.Responses
{
    public class LoginResponseDto
    {
        public string Token { get; }
        public LoginResponseDto(string token)
        {
            Token = token;
        }
    }
}

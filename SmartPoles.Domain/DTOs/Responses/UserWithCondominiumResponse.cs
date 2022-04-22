namespace SmartPoles.Domain.DTOs.Responses
{
    public class UserWithCondominiumResponse
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public CondominiumResponse Condominium { get; set; }
    }
}

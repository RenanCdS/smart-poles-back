using System;
namespace SmartPoles.Domain.DTOs.Responses
{
    public class CondominiumResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Image { get; set; }
    }
}

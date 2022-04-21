using System;

namespace SmartPoles.Domain.DTOs.Requests
{
    public class UpdateCondominiumDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Image { get; set; }
    }
}

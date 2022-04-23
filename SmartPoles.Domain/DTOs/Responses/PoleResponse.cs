using System;

namespace SmartPoles.Domain.DTOs.Responses
{
    public class PoleResponse
    {
        public Guid Id { get; set; }
        public Guid CondominiumId { get; set; }
        public bool IsGateway { get; set; }
        public DateTime CreatedAt { get; set; }
        public CondominiumResponse Condominium { get; set; }
    }
}

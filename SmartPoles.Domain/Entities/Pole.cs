using System;

namespace SmartPoles.Domain.Entities
{
    public class Pole : Base
    {
        public Guid Id { get; set; }
        public Guid CondominiumId { get; set; }
        public bool IsGateway { get; set; }
        public Condominium Condominium { get; set; }
    }
}

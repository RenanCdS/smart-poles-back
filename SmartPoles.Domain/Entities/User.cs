using System;

namespace SmartPoles.Domain.Entities
{
    public class User : Base
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public Guid CondominiumId { get; set; }
        public Condominium Condominium { get; set; }
        public string Role { get; set; }
    }
}

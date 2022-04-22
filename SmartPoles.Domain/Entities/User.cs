using SmartPoles.CrossCutting.Enums;
using System;
using System.Security.Cryptography;

namespace SmartPoles.Domain.Entities
{
    public class User : Base
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public Guid CondominiumId { get; set; }
        public Condominium Condominium { get; set; }
        public Role Role { get; set; }

        public void GenerateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var generator = RandomNumberGenerator.Create())
            {
               generator.GetBytes(randomBytes);
               Salt = Convert.ToBase64String(randomBytes);
            }
        }
    }
}

using System;

namespace SmartPoles.Domain.Entities
{
    public class Condominium : Base
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Image { get; set; }
        public User User { get; set; }
    }
}

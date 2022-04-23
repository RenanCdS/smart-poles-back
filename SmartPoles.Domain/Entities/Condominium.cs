using System;
using System.Collections.Generic;

namespace SmartPoles.Domain.Entities
{
    public class Condominium : Base
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Image { get; set; }
        public IEnumerable<User> User { get; set; }
    }
}

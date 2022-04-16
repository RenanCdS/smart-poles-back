using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPoles.Domain.Entities
{
    public class Condominium : Base
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Image { get; set; }
        public User User { get; set; }
    }
}

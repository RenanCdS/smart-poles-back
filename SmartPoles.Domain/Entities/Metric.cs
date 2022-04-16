using System;

namespace SmartPoles.Domain.Entities
{
    public class Metric : Base
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

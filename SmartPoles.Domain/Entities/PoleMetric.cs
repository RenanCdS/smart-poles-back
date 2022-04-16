using System;

namespace SmartPoles.Domain.Entities
{
    public class PoleMetric : Base
    {
        public Guid Id { get; set; }
        public Guid PoleId { get; set; }
        public Guid MetricId { get; set; }
        public Pole Pole { get; set; }
        public Metric Metric { get; set; }
    }
}

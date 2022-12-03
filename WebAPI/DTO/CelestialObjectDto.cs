using System;

namespace WebAPI.DTO
{
    public class CelestialObjectDto
    {
        public string Name { get; set; }
        public double Mass { get; set; }
        public double EquatorialDiameter { get; set; }
        public int SurfaceTemperature { get; set; }
        public DateTime DiscoveryDate { get; set; }
        public DiscoverySourceDto DiscoverySource { get; set; }
        public ObjectTypeDto ObjectType { get; set; }
    }
}

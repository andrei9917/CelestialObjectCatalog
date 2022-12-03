using System;

namespace WebAPI.Models
{
    public class CelestialObject
    {
        public int CelestialObjectId { get; set; }
        public string Name { get; set; }
        public double Mass { get; set; }
        public double EquatorialDiameter { get; set; }
        public int SurfaceTemperature { get; set; }
        public DateTime DiscoveryDate { get; set; }

        public int DiscoverySourceId { get; set; }
        public DiscoverySource DiscoverySource { get; set; }

        public int ObjectTypeId { get; set; }
        public ObjectType ObjectType { get; set; }
    }
}

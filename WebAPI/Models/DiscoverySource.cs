using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class DiscoverySource
    {
        public int DiscoverySourceId { get; set; }
        public string Name { get; set; }
        public DateTime EstablishmentDate { get; set; }
        public string StateOwner { get; set; }

        public int DiscoverySourceTypeId { get; set; }
        public DiscoverySourceType DiscoverySourceType { get; set; }

        public ICollection<CelestialObject> CelestialObjects { get; set; }
    }
}

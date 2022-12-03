using System.Collections.Generic;

namespace WebAPI.Models
{
    public class DiscoverySourceType
    {
        public int DiscoverySourceTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<DiscoverySource> DiscoverySources { get; set; }
    }
}

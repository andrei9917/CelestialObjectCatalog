using System;

namespace WebAPI.DTO
{
    public class DiscoverySourceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EstablishmentDate { get; set; }
        public string StateOwner { get; set; }
        public DiscoverySourceTypeDto DiscoverySourceType { get; set; }
    }
}

using WebAPI.DTO;
using WebAPI.Mapper.Abstract;
using WebAPI.Models;

namespace WebAPI.Mapper.Concrete
{
    public class DiscoverySourceTypeMapper : IDiscoverySourceTypeMapper
    {
        public DiscoverySourceTypeDto MapDiscoverySourceTypeToDto(DiscoverySourceType discSrcTypeObj)
        {
            return new()
            {
                Id = discSrcTypeObj.DiscoverySourceTypeId,
                Name = discSrcTypeObj.Name
            };
        }
    }
}

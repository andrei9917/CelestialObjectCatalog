using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Mapper.Abstract
{
    public interface IDiscoverySourceTypeMapper
    {
        public DiscoverySourceTypeDto MapDiscoverySourceTypeToDto(DiscoverySourceType discSrcTypeObj);
    }
}

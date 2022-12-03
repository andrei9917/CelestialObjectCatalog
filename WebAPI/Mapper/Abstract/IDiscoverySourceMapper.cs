using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Mapper.Abstract
{
    public interface IDiscoverySourceMapper
    {
        DiscoverySourceDto MapDiscoverySourceToDto(DiscoverySource discSrcObj);
    }
}

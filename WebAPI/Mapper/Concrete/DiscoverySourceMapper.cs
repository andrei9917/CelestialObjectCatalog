using WebAPI.DTO;
using WebAPI.Mapper.Abstract;
using WebAPI.Models;

namespace WebAPI.Mapper.Concrete
{
    public class DiscoverySourceMapper : IDiscoverySourceMapper
    {
        private readonly IDiscoverySourceTypeMapper _discSrcTypeMapper;

        public DiscoverySourceMapper(IDiscoverySourceTypeMapper discSrcTypeMapper)
        {
            _discSrcTypeMapper = discSrcTypeMapper;
        }

        public DiscoverySourceDto MapDiscoverySourceToDto(DiscoverySource discSrcObj)
        {
            return new()
            {
                Id = discSrcObj.DiscoverySourceId,
                Name = discSrcObj.Name,
                EstablishmentDate = discSrcObj.EstablishmentDate,
                StateOwner = discSrcObj.StateOwner,
                DiscoverySourceType = _discSrcTypeMapper.MapDiscoverySourceTypeToDto(discSrcObj.DiscoverySourceType)
            };
        }
    }
}

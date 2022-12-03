using WebAPI.DTO;
using WebAPI.Mapper.Abstract;
using WebAPI.Models;

namespace WebAPI.Mapper.Concrete
{
    public class CelestialObjectMapper : ICelestialObjectMapper
    {
        private readonly IDiscoverySourceMapper _discSrcMapper;
        private readonly IObjectTypeMapper _objTypeMapper;

        public CelestialObjectMapper(IDiscoverySourceMapper discSrcMapper,
                                     IObjectTypeMapper objTypeMapper)
        {
            _discSrcMapper = discSrcMapper;
            _objTypeMapper = objTypeMapper;
        }

        public CelestialObjectDto MapCelestialObjectToDto(CelestialObject celObj)
        {
            return new()
            {
                Name = celObj.Name,
                Mass = celObj.Mass,
                EquatorialDiameter = celObj.EquatorialDiameter,
                SurfaceTemperature = celObj.SurfaceTemperature,
                DiscoveryDate = celObj.DiscoveryDate.Date,
                DiscoverySource = _discSrcMapper.MapDiscoverySourceToDto(celObj.DiscoverySource),
                ObjectType = _objTypeMapper.MapObjectTypeToDto(celObj.ObjectType)
            };
        }

        public CelestialObject MapCelestialObjectInsertToCelestialObject(CelestialObjectInsert celObjIns)
        {
            return new()
            {
                Name = celObjIns.Name,
                Mass = celObjIns.Mass,
                EquatorialDiameter = celObjIns.EquatorialDiameter,
                SurfaceTemperature = celObjIns.SurfaceTemperature,
                DiscoveryDate = celObjIns.DiscoveryDate.Date,
                DiscoverySourceId = celObjIns.DiscoverySourceId
            };
        }
    }
}

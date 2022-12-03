using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Mapper.Abstract
{
    public interface ICelestialObjectMapper
    {
        public CelestialObjectDto MapCelestialObjectToDto(CelestialObject celObj);
        public CelestialObject MapCelestialObjectInsertToCelestialObject(CelestialObjectInsert celObjIns);
    }
}

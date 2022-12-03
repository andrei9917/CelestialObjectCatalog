using WebAPI.Models;

namespace WebAPI.Services
{
    public interface ICelestialObjectClassifierService
    {
        public CelestialObject ClassifyCelestialObject(CelestialObject celObj);
    }
}

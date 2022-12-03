using WebAPI.Constants;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class CelestialObjectClassifierService : ICelestialObjectClassifierService
    {
        public CelestialObject ClassifyCelestialObject(CelestialObject celObj)
        {
            var jupiterMass = 1.898e27;

            var schwarzschildRadiusNumerator = 2 * 6.67408 * celObj.Mass;
            var schwarzschildRadiusDenominator = 8.9875518e27;

            var schwarzschildRadius = schwarzschildRadiusNumerator / schwarzschildRadiusDenominator;

            if ((celObj.EquatorialDiameter / 2) < schwarzschildRadius)
            {
                celObj.ObjectTypeId = (int)ObjectTypes.BlackHole;
                return celObj;
            }

            if (celObj.Mass < jupiterMass)
            {
                celObj.ObjectTypeId = (int)ObjectTypes.Planet;
                return celObj;
            }

            if (celObj.SurfaceTemperature >= 2500)
            {
                celObj.ObjectTypeId = (int)ObjectTypes.Star;
                return celObj;
            }

            celObj.ObjectTypeId = (int)ObjectTypes.Unknown;
            return celObj;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DTO;
using WebAPI.Mapper.Abstract;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CelestialObjectsController : ControllerBase
    {
        private readonly CatalogDbContext _dbContext;
        private readonly ICelestialObjectClassifierService _celObjClassifier;
        private readonly ICelestialObjectMapper _celObjMapper;

        public CelestialObjectsController(CatalogDbContext dbContext,
                                          ICelestialObjectClassifierService celObjClassifier,
                                          ICelestialObjectMapper celObjMapper)
        {
            _dbContext = dbContext;
            _celObjClassifier = celObjClassifier;
            _celObjMapper = celObjMapper;
        }

        // GET: api/CelestialObjects?type=XYZ&name=XYZ&country&XYZ
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CelestialObjectDto>>> GetCelestialObjects([FromQuery] string type="",
                                                                                             [FromQuery] string name="",
                                                                                             [FromQuery] string country="")
        {
            IQueryable<CelestialObject> celestialObjects = _dbContext.CelestialObject;
            
            if (type != "") //check for 'type' query parameter
            {
                var objectType = await _dbContext.ObjectType.FirstOrDefaultAsync(ot => ot.Name == type);

                if (objectType == null)
                {
                    return NotFound("I didn't recognize that type of object");
                }

                celestialObjects = celestialObjects.Where(co => co.ObjectTypeId == objectType.ObjectTypeId);
            }

            if (name != "") //check for 'name' query parameter
            {
                celestialObjects = celestialObjects.Where(co => co.Name == name);
            }

            if (country != "") //check for 'country' query parameter
            {
                var discoverySourcesOfGivenCountry = _dbContext.DiscoverySource.Where(ds => ds.StateOwner == country);

                if (!discoverySourcesOfGivenCountry.Any())
                {
                    return NotFound("No discovery sources found by given country");
                }

                celestialObjects = celestialObjects.Where(co => discoverySourcesOfGivenCountry.Any(dsogc => dsogc.DiscoverySourceId == co.DiscoverySourceId));
            }

            var celestialObjectDtos = new List<CelestialObjectDto>();

            foreach (var celObj in celestialObjects.ToList())
            {
                await EnrichCelestialObjectDataAsync(celObj);

                var celObjDto = _celObjMapper.MapCelestialObjectToDto(celObj);
                celestialObjectDtos.Add(celObjDto);
            }

            return celestialObjectDtos;
        }

        // POST: api/CelestialObjects
        [HttpPost]
        public async Task<ActionResult<CelestialObjectDto>> PostCelestialObject(CelestialObjectInsert celestialObjectInsert)
        {
            var celestialObject = _celObjMapper.MapCelestialObjectInsertToCelestialObject(celestialObjectInsert);

            _celObjClassifier.ClassifyCelestialObject(celestialObject);

            _dbContext.CelestialObject.Add(celestialObject);
            await _dbContext.SaveChangesAsync();

            await EnrichCelestialObjectDataAsync(celestialObject);
            var celObjDto = _celObjMapper.MapCelestialObjectToDto(celestialObject);

            return celObjDto;
        }

        private async Task EnrichCelestialObjectDataAsync(CelestialObject celObj)
        {
            celObj.DiscoverySource = await _dbContext.DiscoverySource.FirstOrDefaultAsync(ds => ds.DiscoverySourceId == celObj.DiscoverySourceId);
            celObj.DiscoverySource.DiscoverySourceType = await _dbContext.DiscoverySourceType.FirstOrDefaultAsync(dst => dst.DiscoverySourceTypeId == celObj.DiscoverySource.DiscoverySourceTypeId);
            celObj.ObjectType = await _dbContext.ObjectType.FirstOrDefaultAsync(ot => ot.ObjectTypeId == celObj.ObjectTypeId);
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DTO;
using WebAPI.Mapper;
using WebAPI.Mapper.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscoverySourceTypesController : ControllerBase
    {
        private readonly CatalogDbContext _dbContext;
        private readonly IDiscoverySourceTypeMapper _mapper;

        public DiscoverySourceTypesController(CatalogDbContext dbContext,
                                              IDiscoverySourceTypeMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        // GET: api/DiscoverySourceTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiscoverySourceTypeDto>>> GetDiscoverySourceType()
        {
            var discoverySourceTypes = await _dbContext.DiscoverySourceType.ToListAsync();

            var discoverySourceTypeDtos = new List<DiscoverySourceTypeDto>();

            foreach (var discSrcType in discoverySourceTypes)
            {
                var discSrcTypeDto = _mapper.MapDiscoverySourceTypeToDto(discSrcType);
                discoverySourceTypeDtos.Add(discSrcTypeDto);
            }

            return discoverySourceTypeDtos;
        }
    }
}

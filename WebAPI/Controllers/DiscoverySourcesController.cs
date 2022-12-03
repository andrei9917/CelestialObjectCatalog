using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DTO;
using WebAPI.Mapper.Abstract;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscoverySourcesController : ControllerBase
    {
        private readonly CatalogDbContext _dbContext;
        private readonly IDiscoverySourceMapper _mapper;

        public DiscoverySourcesController(CatalogDbContext dbContext,
                                          IDiscoverySourceMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        // GET: api/DiscoverySources
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiscoverySourceDto>>> GetDiscoverySource()
        {
            var discoverySources = await _dbContext.DiscoverySource.ToListAsync();

            var discoverySourceDtos = new List<DiscoverySourceDto>();

            foreach (var discSrc in discoverySources)
            {
                discSrc.DiscoverySourceType =
                    await _dbContext.DiscoverySourceType.FirstOrDefaultAsync(dst =>
                        dst.DiscoverySourceTypeId == discSrc.DiscoverySourceTypeId);

                var discSrcDto = _mapper.MapDiscoverySourceToDto(discSrc);
                discoverySourceDtos.Add(discSrcDto);
            }

            return discoverySourceDtos;
        }
    }
}

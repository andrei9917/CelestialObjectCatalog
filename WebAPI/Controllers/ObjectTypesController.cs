using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DTO;
using WebAPI.Mapper;
using WebAPI.Mapper.Abstract;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectTypesController : ControllerBase
    {
        private readonly CatalogDbContext _dbContext;
        private readonly IObjectTypeMapper _mapper;

        public ObjectTypesController(CatalogDbContext dbContext,
                                     IObjectTypeMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        // GET: api/ObjectTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObjectTypeDto>>> GetObjectType()
        {
            var objectTypes = await _dbContext.ObjectType.ToListAsync();

            var objectTypeDtos = new List<ObjectTypeDto>();

            foreach (var objType in objectTypes)
            {
                var objTypeDto = _mapper.MapObjectTypeToDto(objType);
                objectTypeDtos.Add(objTypeDto);
            }

            return objectTypeDtos;
        }
    }
}

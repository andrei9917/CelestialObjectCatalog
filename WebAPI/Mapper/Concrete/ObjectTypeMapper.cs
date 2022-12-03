using WebAPI.DTO;
using WebAPI.Mapper.Abstract;
using WebAPI.Models;

namespace WebAPI.Mapper.Concrete
{
    public class ObjectTypeMapper : IObjectTypeMapper
    {
        public ObjectTypeDto MapObjectTypeToDto(ObjectType objectTypeObj)
        {
            return new()
            {
                Id = objectTypeObj.ObjectTypeId,
                Name = objectTypeObj.Name
            };
        }
    }
}

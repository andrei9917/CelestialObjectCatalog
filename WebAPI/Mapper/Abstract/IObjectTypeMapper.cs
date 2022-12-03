using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Mapper.Abstract
{
    public interface IObjectTypeMapper
    {
        ObjectTypeDto MapObjectTypeToDto(ObjectType objectTypeObj);
    }
}

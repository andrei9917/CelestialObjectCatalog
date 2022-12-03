using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI.Mapper.Concrete;
using WebAPI.Models;

namespace WebAPITests.Mapper.Concrete
{
    [TestClass]
    public class ObjectTypeMapperTests
    {
        [TestMethod]
        public void MapObjectTypeToDtoTest_SuccessfulMapping()
        {
            //arrange
            var objType = new ObjectType()
            {
                ObjectTypeId = 1,
                Name = "object type name"
            };

            var mapper = new ObjectTypeMapper();

            //act
            var objTypeDto = mapper.MapObjectTypeToDto(objType);

            //assert
            Assert.AreEqual(objTypeDto.Id, objType.ObjectTypeId);
            Assert.AreEqual(objTypeDto.Name, objType.Name);
        }
    }
}
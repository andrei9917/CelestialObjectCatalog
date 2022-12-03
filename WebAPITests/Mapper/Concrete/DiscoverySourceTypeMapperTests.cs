using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI.Mapper.Concrete;
using WebAPI.Models;

namespace WebAPITests.Mapper.Concrete
{
    [TestClass]
    public class DiscoverySourceTypeMapperTests
    {
        [TestMethod]
        public void MapDiscoverySourceTypeToDtoTest_SuccessfulMapping()
        {
            //arrange
            var discSrcType = new DiscoverySourceType()
            {
                DiscoverySourceTypeId = 1,
                Name = "object type name"
            };

            var mapper = new DiscoverySourceTypeMapper();

            //act
            var discSrcTypeDto = mapper.MapDiscoverySourceTypeToDto(discSrcType);

            //assert
            Assert.AreEqual(discSrcTypeDto.Id, discSrcType.DiscoverySourceTypeId);
            Assert.AreEqual(discSrcTypeDto.Name, discSrcType.Name);
        }
    }
}
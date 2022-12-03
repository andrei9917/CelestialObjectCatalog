using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebAPI.DTO;
using WebAPI.Mapper.Abstract;
using WebAPI.Mapper.Concrete;
using WebAPI.Models;

namespace WebAPITests.Mapper.Concrete
{
    [TestClass]
    public class DiscoverySourceMapperTests
    {
        [TestMethod]
        public void MapDiscoverySourceToDtoTest()
        {
            //arrange
            var discSrc = new DiscoverySource()
            {
                DiscoverySourceId = 2,
                Name = "Arecibo Observatory",
                EstablishmentDate = new DateTime(1960, 06, 01),
                DiscoverySourceTypeId = 2,
                StateOwner = "Puerto Rico"
            };

            var discSrcTypeMock = new Mock<IDiscoverySourceTypeMapper>();
            discSrcTypeMock.Setup(mapper => mapper.MapDiscoverySourceTypeToDto(discSrc.DiscoverySourceType))
                .Returns(new DiscoverySourceTypeDto() { Id = discSrc.DiscoverySourceTypeId });

            var discSrcMapper = new DiscoverySourceMapper(discSrcTypeMock.Object);

            //act
            var newDiscSrcDto = discSrcMapper.MapDiscoverySourceToDto(discSrc);

            //assert
            Assert.AreEqual(discSrc.DiscoverySourceId, newDiscSrcDto.Id);
            Assert.AreEqual(discSrc.Name, newDiscSrcDto.Name);
            Assert.AreEqual(discSrc.EstablishmentDate, newDiscSrcDto.EstablishmentDate);
            Assert.AreEqual(discSrc.DiscoverySourceTypeId, newDiscSrcDto.DiscoverySourceType.Id);
            Assert.AreEqual(discSrc.StateOwner, newDiscSrcDto.StateOwner);
        }
    }
}
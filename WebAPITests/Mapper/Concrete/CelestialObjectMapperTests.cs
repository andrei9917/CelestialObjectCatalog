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
    public class CelestialObjectMapperTests
    {
        [TestMethod]
        public void MapCelestialObjectToDtoTest_SuccessfulMapping()
        {
            //arrange
            var celObj = new CelestialObject()
            {
                Name = "X1 NGC 4889",
                Mass = 4.2e40,
                EquatorialDiameter = 4280000,
                SurfaceTemperature = 2000,
                DiscoveryDate = new DateTime(2019, 03, 10),
                DiscoverySource = new DiscoverySource(),
                ObjectType = new ObjectType()
            };

            var discSrcMock = new Mock<IDiscoverySourceMapper>();
            discSrcMock.Setup(mapper => mapper.MapDiscoverySourceToDto(celObj.DiscoverySource))
                .Returns(new DiscoverySourceDto() { Id = celObj.DiscoverySourceId });

            var objTypeMock = new Mock<IObjectTypeMapper>();
            objTypeMock.Setup(mapper => mapper.MapObjectTypeToDto(celObj.ObjectType))
                .Returns(new ObjectTypeDto() { Id = celObj.ObjectTypeId });

            var celObjMapper = new CelestialObjectMapper(discSrcMock.Object, objTypeMock.Object);

            //act
            var newCelObjDto = celObjMapper.MapCelestialObjectToDto(celObj);

            //assert
            Assert.AreEqual(celObj.Name, newCelObjDto.Name);
            Assert.AreEqual(celObj.Mass, newCelObjDto.Mass);
            Assert.AreEqual(celObj.EquatorialDiameter, newCelObjDto.EquatorialDiameter);
            Assert.AreEqual(celObj.SurfaceTemperature, newCelObjDto.SurfaceTemperature);
            Assert.AreEqual(celObj.DiscoveryDate, newCelObjDto.DiscoveryDate);
            Assert.AreEqual(celObj.DiscoverySourceId, newCelObjDto.DiscoverySource.Id);
            Assert.AreEqual(celObj.ObjectTypeId, newCelObjDto.ObjectType.Id);
        }

        [TestMethod]
        public void MapCelestialObjectInsertToCelestialObject_SuccessfulMapping()
        {
            //arrange
            var celObjIns = new CelestialObjectInsert()
            {
                Name = "X1 NGC 4889",
                Mass = 4.2e40,
                EquatorialDiameter = 4280000,
                SurfaceTemperature = 2000,
                DiscoveryDate = new DateTime(2019, 03, 10),
                DiscoverySourceId = 1
            };

            var discSrcMock = new Mock<IDiscoverySourceMapper>();
            var objTypeMock = new Mock<IObjectTypeMapper>();

            var celObjMapper = new CelestialObjectMapper(discSrcMock.Object, objTypeMock.Object);

            //act
            var newCelObj = celObjMapper.MapCelestialObjectInsertToCelestialObject(celObjIns);

            //assert
            Assert.AreEqual(celObjIns.Name, newCelObj.Name);
            Assert.AreEqual(celObjIns.Mass, newCelObj.Mass);
            Assert.AreEqual(celObjIns.EquatorialDiameter, newCelObj.EquatorialDiameter);
            Assert.AreEqual(celObjIns.SurfaceTemperature, newCelObj.SurfaceTemperature);
            Assert.AreEqual(celObjIns.DiscoveryDate, newCelObj.DiscoveryDate);
            Assert.AreEqual(celObjIns.DiscoverySourceId, newCelObj.DiscoverySourceId);
        }
    }
}
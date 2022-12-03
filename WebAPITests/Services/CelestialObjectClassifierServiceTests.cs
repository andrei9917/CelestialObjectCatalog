using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI.Constants;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPITests.Services
{
    [TestClass]
    public class CelestialObjectClassifierServiceTests
    {
        [TestMethod]
        public void ClassifyCelestialObjectTest_ObjectTypeBlackHole()
        {
            //arrange
            var celObj = new CelestialObject()
            {
                Name = "X1 NGC 4889",
                Mass = 4.2e40,
                EquatorialDiameter = 4280000,
                SurfaceTemperature = 2000,
                DiscoveryDate = new DateTime(2019, 03, 10),
                DiscoverySourceId = 9
            };

            var celObjClassifier = new CelestialObjectClassifierService();

            //act
            celObjClassifier.ClassifyCelestialObject(celObj);

            //assert
            Assert.AreEqual((int)ObjectTypes.BlackHole, celObj.ObjectTypeId);
        }

        [TestMethod]
        public void ClassifyCelestialObjectTest_ObjectTypePlanet()
        {
            //arrange
            var celObj = new CelestialObject()
            {
                Name = "Kepler-37b",
                Mass = 5.97237e24,
                EquatorialDiameter = 12756200,
                SurfaceTemperature = 5800,
                DiscoveryDate = new DateTime(2018, 12, 15),
                DiscoverySourceId = 1
            };

            var celObjClassifier = new CelestialObjectClassifierService();

            //act
            celObjClassifier.ClassifyCelestialObject(celObj);

            //assert
            Assert.AreEqual((int)ObjectTypes.Planet, celObj.ObjectTypeId);
        }

        [TestMethod]
        public void ClassifyCelestialObjectTest_ObjectTypeStar()
        {
            //arrange
            var celObj = new CelestialObject()
            {
                Name = "V538 Carinae",
                Mass = 3.65e29,
                EquatorialDiameter = 184502000,
                SurfaceTemperature = 4800,
                DiscoveryDate = new DateTime(2010, 01, 25),
                DiscoverySourceId = 6
            };

            var celObjClassifier = new CelestialObjectClassifierService();

            //act
            celObjClassifier.ClassifyCelestialObject(celObj);

            //assert
            Assert.AreEqual((int)ObjectTypes.Star, celObj.ObjectTypeId);
        }

        [TestMethod]
        public void ClassifyCelestialObjectTest_ObjectTypeUnknown()
        {
            //arrange
            var celObj = new CelestialObject()
            {
                Name = "Z0 B1257+12",
                Mass = 2.91e28,
                EquatorialDiameter = 55000000,
                SurfaceTemperature = 1600,
                DiscoveryDate = new DateTime(2020, 05, 30),
                DiscoverySourceId = 7
            };

            var celObjClassifier = new CelestialObjectClassifierService();

            //act
            celObjClassifier.ClassifyCelestialObject(celObj);

            //assert
            Assert.AreEqual((int)ObjectTypes.Unknown, celObj.ObjectTypeId);
        }
    }
}
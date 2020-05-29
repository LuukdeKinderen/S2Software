using System;
using System.Collections.Generic;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class ShipTest
    {
        [TestMethod]
        public void ShipSizeCanBeSetOnConstruction()
        {
            Ship ship1 = new Ship(6, 8);
            Ship ship2 = new Ship(16, 5);

            Assert.AreEqual(ship1.xLength, 6);
            Assert.AreEqual(ship1.yLength, 8);

            Assert.AreEqual(ship2.xLength, 16);
            Assert.AreEqual(ship2.yLength, 5);
        }


        [TestMethod]
        public void WhenShipIsFilledItIsInBalance()
        {
            Ship ship = new Ship(6, 8);
            List<Container> containers = ContainerConstructor.CreateRandomContainers(1000);

            ship.DistributeMaxAndReturn(containers);

            if (ship.PercentageLeft < 40 || ship.PercentageLeft > 60)
            {
                Assert.Fail();
            }
            if (ship.PercentageRight < 40 || ship.PercentageRight > 60)
            {
                Assert.Fail();
            }
        }
    }
}

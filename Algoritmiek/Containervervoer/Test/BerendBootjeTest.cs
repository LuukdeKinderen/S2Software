using System;
using System.Collections.Generic;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class BerendBootjeTest
    {
        [TestMethod]
        public void EachShipIsAtLeastFiftyPercentFilled()
        {
            BerendBootje berendBootje = new BerendBootje();
            berendBootje.AddRandomContianers(3000);
            berendBootje.SetShipFormat(6, 12);

            berendBootje.DistributeContainers();

            foreach (Ship ship in berendBootje.shipCollection)
            {
                if (ship.PercentageOfMaxWeight < 50)
                {
                    Assert.Fail();
                }
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Circustrein.Test
{
    [TestClass]
    public class TreinTest
    {

        [TestMethod]
        public void ErZijnGeenLegeWagonsNaHetIndelenVanDieren()
        {
            //Arrange
            List<Dier> dieren = DierFactory.randomDieren(10);
            Trein trein = new Trein();

            //Act
            trein.AddDieren(dieren);
            trein.VerdeelDieren();


            //Assert
            foreach (Wagon wagon in trein.treinWagons)
            {
                Assert.IsTrue(wagon.Waarde > 0);
            }
        }
        [TestMethod]
        public void AlleDierenZijnIngedeeldInEenWagon()
        {
            //Arrange
            List<Dier> dieren = DierFactory.randomDieren(10);
            Trein trein = new Trein();

            //Act
            trein.AddDieren(dieren);
            trein.VerdeelDieren();


            //Assert
            foreach (Dier dier in dieren)
            {
                bool found = false;
                foreach (Wagon wagon in trein.treinWagons)
                {
                    List<Dier> wagonDieren = new List<Dier>(wagon.wagonDieren);
                    if (wagonDieren.IndexOf(dier) >= 0)
                    {
                        found = true;
                    }
                }
                Assert.IsTrue(found);
            }
        }


    }
}

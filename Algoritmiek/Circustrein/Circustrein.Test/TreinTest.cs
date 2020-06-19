using System;
using System.Collections.Generic;
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

            List<Dier> dieren = new List<Dier>
            {
                new Dier(false,Formaat.groot),
                new Dier(false,Formaat.groot),
                new Dier(false,Formaat.groot),
                new Dier(false,Formaat.groot),
                new Dier(false,Formaat.groot),
            };
            Trein trein = new Trein();
            trein.AddDieren(dieren);

            //Act
            trein.VerdeelDieren();


            //Assert
            Assert.IsTrue(trein.treinWagons[0].Waarde > 0);
            Assert.IsTrue(trein.treinWagons[1].Waarde > 0);
            Assert.IsTrue(trein.treinWagons[2].Waarde > 0);

        }


        [TestMethod]
        public void TreinMaaktZelfWagonsAan()
        {
            //Arrange
            Dier dier1 = new Dier(true, Formaat.klein);
            Dier dier2 = new Dier(false, Formaat.klein);
            List<Dier> dieren = new List<Dier>()
            {
                dier1,
                dier2,
            };
            Trein trein = new Trein();
            trein.AddDieren(dieren);


            //Act
            trein.VerdeelDieren();

            //Assert
            Assert.AreEqual(trein.treinWagons.Count, 2);
        }
    }
}

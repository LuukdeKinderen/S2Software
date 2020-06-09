using Microsoft.VisualStudio.TestTools.UnitTesting;
using Circustrein;

namespace Circustrein.Test
{
    [TestClass]
    public class WagonTest
    {
        [TestMethod]
        public void VleesEterErbijLuktNietAlsVleesEterGroterIsDanPlantenEter()
        {
            //Arrange
            Dier plantEterKlein = new Dier(false, Formaat.klein);
            Dier vleesEterGroot = new Dier(true, Formaat.groot);
            Wagon wagon = new Wagon();

            //Act
            wagon.TryAndAddDier(plantEterKlein);
            bool result = wagon.TryAndAddDier(vleesEterGroot);

            //Assert
            Assert.IsFalse(result);
            Assert.IsTrue(plantEterKlein.formaat < vleesEterGroot.formaat);
        }

        [TestMethod]
        public void VleesEterErbijLuktNietAlsVleesEterGelijkIsAanAndereVleesEter()
        {
            //Arrange
            Dier vleesEterMiddelEen = new Dier(true, Formaat.middel);
            Dier vleesEterMiddelTwee = new Dier(true, Formaat.middel);
            Wagon wagon = new Wagon();

            //Act
            wagon.TryAndAddDier(vleesEterMiddelEen);
            bool result = wagon.TryAndAddDier(vleesEterMiddelTwee);

            //Assert
            Assert.IsFalse(result);
            Assert.IsTrue(vleesEterMiddelEen.formaat == vleesEterMiddelTwee.formaat);
        }

        [TestMethod]
        public void PlantenEterErbijLuktWelAlsHijGroterIsDanVleesEter()
        {
            //Arrange
            Dier plantEterGroot = new Dier(false, Formaat.groot);
            Dier vleesEterklein = new Dier(true, Formaat.klein);
            Wagon wagon = new Wagon();

            //Act
            wagon.TryAndAddDier(vleesEterklein);
            bool result = wagon.TryAndAddDier(plantEterGroot);
            
            //Assert
            Assert.IsTrue(result);
            Assert.IsTrue(plantEterGroot.formaat > vleesEterklein.formaat);
        }

        [TestMethod]
        public void DierErbijLuktNietAlsWaardeMeerWordtDanTien()
        {
            //Arrange
            Dier plantGrootEen = new Dier(false, Formaat.groot);
            Dier plantGrootTwee = new Dier(false, Formaat.groot);
            Dier plantGrootDrie = new Dier(false, Formaat.groot);
            Wagon wagon = new Wagon();

            //Act
            wagon.TryAndAddDier(plantGrootEen);
            wagon.TryAndAddDier(plantGrootTwee);
            int beginWaarde = wagon.Waarde;
            int newWaarde = wagon.Waarde + (int)plantGrootDrie.formaat;
            bool result = wagon.TryAndAddDier(plantGrootDrie);

            //Assert
            Assert.AreEqual(beginWaarde, 10);
            Assert.IsTrue(newWaarde > 10);
            Assert.IsFalse(result);
        }

    }
}

using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class ContainerTest
    {
        [TestMethod]
        public void ContianerCanBeConstructedWithValues()
        {
            Container c = new Container(true, false, 5000);

            Assert.AreEqual(c.valuable, true);
            Assert.AreEqual(c.cooled, false);
            Assert.AreEqual(c.weight, 5000);
        }

        [TestMethod]
        public void Container_Is_Never_Lower_Than_Minimum()
        {
            Container c = new Container(true, true, 5);
            
            Assert.AreEqual(c.weight, 4000);
        }

        [TestMethod]
        public void Container_Is_Never_Higher_Than_Maximum()
        {
            Container c = new Container(true, true, 90000);

            Assert.AreEqual(c.weight, 30000);
        }
    }
}
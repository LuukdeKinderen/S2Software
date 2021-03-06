using System;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class StackTest
    {
        [TestMethod]
        public void When_Container_Is_Added_TotalWeight_Is_Increased()
        {
            //Arrange
            Random r = new Random();
            Container c = ContainerConstructor.CreateRandom(r);
            Stack s = new Stack();
            int expected = s.TotalWeight + c.weight;

            //Act
            s.AddContainer(c);

            //Assert
            Assert.AreEqual(expected, s.TotalWeight);
        }

        [TestMethod]
        public void When_BottomLoad_Is_Too_High_Container_Will_Fail_To_Add()
        {
            //Arrange
            Stack s = new Stack();
            s.AddContainer(ContainerConstructor.CreateContainer(false, false, 30000));
            s.AddContainer(ContainerConstructor.CreateContainer(false, false, 30000));
            s.AddContainer(ContainerConstructor.CreateContainer(false, false, 30000));
            s.AddContainer(ContainerConstructor.CreateContainer(false, false, 30000));
            s.AddContainer(ContainerConstructor.CreateContainer(false, false, 30000));

            //Act
            Container testContainer = ContainerConstructor.CreateContainer(false, false, 4000);

            //Assert
            bool addedContainer = s.AddContainer(testContainer);
            bool canFindContainer = s.Containers.Contains(testContainer);
            Assert.IsFalse(addedContainer);
            Assert.IsFalse(canFindContainer);
        }

        [TestMethod]
        public void When_Stack_Already_Has_Valuable_Container_Can_Not_Add_New_Valuable_Container()
        {
            //Arrange
            Stack s = new Stack();
            Container valuable1 = ContainerConstructor.CreateContainer(true, false, 5000);
            Container valuable2 = ContainerConstructor.CreateContainer(true, false, 5000);

            //Act
            s.AddContainer(valuable1);
            
            //Assert
            bool addedContainer = s.AddContainer(valuable2);
            bool canFindContainer = s.Containers.Contains(valuable2);
            Assert.IsFalse(addedContainer);
            Assert.IsFalse(canFindContainer);
        }

        [TestMethod]
        public void ValuableContainerIsAlwaysOnTopOfTheStack()
        {
            //Arrange
            Stack s = new Stack();
            Container c1 = ContainerConstructor.CreateContainer(false, false, 5000);
            Container c2 = ContainerConstructor.CreateContainer(false, false, 5000);
            Container c3 = ContainerConstructor.CreateContainer(false, false, 5000);
            Container valuable = ContainerConstructor.CreateContainer(true, false, 5000);

            //Act
            s.AddContainer(c1);
            s.AddContainer(c2);
            s.AddContainer(c3);            
            s.AddContainer(valuable);

            //Assert
            int indexOfValuable = s.Containers.IndexOf(valuable);
            Assert.AreEqual(0, indexOfValuable);
        }


    }
}

using System;
using System.Collections.Generic;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class RowTest
    {


        [TestMethod]
        public void ShipRow_Contains_Correct_Number_Of_Stacks()
        {
            //Arrange / Act
            ShipRow sr = new ShipRow(7);

            //Assert
            Assert.AreEqual(sr.Stacks.Count, 7);
        }

        [TestMethod]
        public void When_Container_Is_Cooled_It_Only_Ends_Up_In_First_Stack()
        {
            //Arange
            ShipRow sr = new ShipRow(7);

            //Act
            for (int i = 0; i < 30; i++)
            {
                Container cooledContainer = ContainerConstructor.CreateContainer(false, true, 30000);
                sr.AddContainer(cooledContainer);
            }

            //Assert
            Assert.IsTrue(sr.Stacks[0].ContainerCount > 0);
            for (int i = 1; i < sr.Stacks.Count; i++)
            {
                Assert.AreEqual(0, sr.Stacks[i].ContainerCount);
            }
        }

        [TestMethod]
        public void When_Container_Is_Valuable_It_Only_Ends_Up_In_Even_Stacks()
        {
            //Arrange
            ShipRow sr = new ShipRow(7);

            //Act
            for (int i = 0; i < 30; i++)
            {
                Container container = ContainerConstructor.CreateContainer(true, false, 30000);
                sr.AddContainer(container);
            }

            //Assert
            for (int i = 0; i < sr.Stacks.Count; i++)
            {
                if (i % 2 == 0)
                {
                    Assert.AreEqual(1, sr.Stacks[i].ContainerCount);
                }
                else
                {
                    Assert.AreEqual(0, sr.Stacks[i].ContainerCount);
                }
            }
        }

        [TestMethod]
        public void Every_Fourth_Stack_Is_Lower_Than_The_Stack_Before_Or_After_That_If_One_Of_Those_Has_A_Valuable_Container()
        {
            //Arrange
            ShipRow sr = new ShipRow(7);
            List<Container> containers = ContainerConstructor.CreateRandomContainers(500);
            containers.SortForShip();

            //Act
            foreach (Container container in containers)
            {
                sr.AddContainer(container);
            }

            //Assert
            if (sr.Stacks[2].HasValuable && sr.Stacks[3].ContainerCount >= sr.Stacks[2].ContainerCount)
            {
                Assert.Fail();
            }
            if (sr.Stacks[4].HasValuable && sr.Stacks[3].ContainerCount >= sr.Stacks[4].ContainerCount)
            {
                Assert.Fail();
            }
        }
    }
}

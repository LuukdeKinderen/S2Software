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
            ShipRow sr = new ShipRow(7);


            Assert.AreEqual(sr.Stacks.Count, 7);
        }

        [TestMethod]
        public void When_Container_Is_Cooled_It_Only_Ends_Up_In_First_Stack()
        {
            ShipRow sr = new ShipRow(7);

            for (int i = 0; i < 30; i++)
            {
                Container container = ContainerConstructor.CreateContainer(false, true, 30000);
                sr.AddContainer(container);
            }

            Assert.AreEqual(true, sr.Stacks[0].ContainerCount > 0);

            for (int i = 1; i < sr.Stacks.Count; i++)
            {
                Assert.AreEqual(0, sr.Stacks[i].ContainerCount);
            }
        }

        [TestMethod]
        public void When_Container_Is_Valuable_It_Only_Ends_Up_In_Even_Stacks()
        {
            ShipRow sr = new ShipRow(7);

            for (int i = 0; i < 30; i++)
            {
                Container container = ContainerConstructor.CreateContainer(true, false, 30000);
                sr.AddContainer(container);
            }

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
        public void Ever_Fourth_Stack_Is_Lower_Than_The_Stack_Before_Or_After_That_If_One_Of_Those_Has_A_Valuable_Container()
        {
            ShipRow sr = new ShipRow(7);
            List<Container> containers = ContainerConstructor.CreateRandomContainers(500);
            containers.SortForShip();

            foreach (Container container in containers)
            {
                sr.AddContainer(container);
            }


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

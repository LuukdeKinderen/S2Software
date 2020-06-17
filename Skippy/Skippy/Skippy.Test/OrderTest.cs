using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skippy.Logic;

namespace Skippy.Test
{
    [TestClass]
    public class OrderTest
    {

        [TestMethod]
        public void AddProdcutToOrder()
        {
            //Arrange
            OrderContainer orderContainer = new OrderContainer();
            ProductContainer productContainer = new ProductContainer();
            Product product = productContainer.GetByID(1);
           

            //Act
            int id =  orderContainer.CreateNew();
            Order newOrder = orderContainer.GetByID(id);
            OrderRegel orderRegel = new OrderRegel(1, product);
            newOrder.EditOrderRegel(orderRegel);


            //Assert
            Assert.IsTrue(orderContainer.GetByID(id).GetOrderRegels()[0].product.titel == product.titel);
        }

    }
}
